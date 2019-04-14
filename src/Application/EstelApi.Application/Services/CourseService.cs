namespace EstelApi.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.CreateNewCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateAvailableDatesForCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourse;
    using EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourseTopicsForCourse;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec;
    using EstelApi.Core.Seedwork;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.Specifications.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Context.Base;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    public class CourseService : BaseService, ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly IAdditionalAmenityRepository additionalAmenityRepository;
        private readonly IAvailableDatesRepository availableDatesRepository;
        private readonly ICourseTopicsRepository courseTopicsRepository;
        public CourseService(IQueryableUnitOfWork uow, ICourseRepository repository, IAdditionalAmenityRepository additionalAmenityRepository, IAvailableDatesRepository availableDatesRepository, ICourseTopicsRepository courseTopicsRepository)
            : base(uow)
        {
            this.courseRepository = repository;
            this.additionalAmenityRepository = additionalAmenityRepository;
            this.availableDatesRepository = availableDatesRepository;
            this.courseTopicsRepository = courseTopicsRepository;
        }

        public async Task<Course> CreateNewCourse(CreateNewCourseDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);
            var entity = processingEntity.ProjectedAs<Course>();
            this.courseRepository.Add(entity);
            return await this.CommitAsync()
                       ? entity
                       : throw new DatabaseException("Save exeption");
        }
        public async Task<Course> UpdateCourse(UpdateCourseDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var entity = processingEntity.ProjectedAs<Course>();
            this.courseRepository.Modify(entity);
            return await this.CommitAsync()
                       ? entity
                       : throw new DatabaseException("Save exeption");
        }
        public async Task<bool> DeleteCourse(RemoveEntityCommand<Course> processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var current = this.courseRepository.OneMatching(new FindCourseById().SetId(processingEntity.Id));
            this.courseRepository.Remove(current);
            return !await this.CommitAsync()
                       ? throw new DatabaseException("Save exeption")
                       : true;
        }
        public async Task<bool> UpdateAddiAmeForCourse(UpdateAdditionalAmenityForCourseDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);
            var entity = processingEntity.ProjectedAs<AdditionalAmenity>();
            var courseTopics = this.additionalAmenityRepository.OneMatching(new FindAdditionalAmenity(entity));
            if (courseTopics == null)
            {
                var course = this.courseRepository.OneMatching(new FindCourseById().SetId(processingEntity.CourseId));
                course.AdditionalAmenityCourses.Add(new AdditionalAmenityCourse()
                                                        {
                                                            CourseId = processingEntity.CourseId,
                                                            AdditionalAmenity = entity
                                                        });
            }

            else
            {
                var course = this.courseRepository.OneMatching(new FindCourseById().SetId(processingEntity.CourseId));
                course.AdditionalAmenityCourses.Add(new AdditionalAmenityCourse()
                                                        {
                                                            CourseId = processingEntity.CourseId,
                                                            AdditionalAmenity = courseTopics
                                                        });
            }
            return await this.CommitAsync()
                       ? true
                       : throw new DatabaseException("Save exeption");

        }
        public async Task<bool> UpdateAvailDateForCourse(UpdateAvailableDatesForCourseDto processingEntity)
        {
            var entity = processingEntity.ProjectedAs<AvailableDates>();
            var availableDates = this.availableDatesRepository.OneMatching(new FindAvailableDates(entity));
            if (availableDates == null)
            {
                var course = this.courseRepository.OneMatching(new FindCourseById().SetId(processingEntity.CourseId));
                course.AvailableDates.Add(new AvailableDatesCourse
                                              {
                                                  CourseId = processingEntity.CourseId,
                                                  AvailableDates = entity
                                              });
            }
            else
            {
                var course = this.courseRepository.OneMatching(new FindCourseById().SetId(processingEntity.CourseId));
                course.AvailableDates.Add(new AvailableDatesCourse
                                              {
                                                  CourseId = processingEntity.CourseId,
                                                  AvailableDates = availableDates
                                              });
            }

            return await this.CommitAsync()
                       ? true
                       : throw new DatabaseException("Save exeption");
        }
        public async Task<bool> UpdateCourseTopics(UpdateCourseTopicsForCourseDto processingEntity)
        {
            var entity = processingEntity.ProjectedAs<CourseTopics>();
            var courseTopics = this.courseTopicsRepository.OneMatching(new FindCourseTopics(entity));
            if (courseTopics == null)
            {
                var course = this.courseRepository.OneMatching(new FindCourseById().SetId(processingEntity.CourseId));
                course.CourseTopics.Add(new CourseTopicsCourse
                                            {
                                                CourseId = processingEntity.CourseId,
                                                CourseTopics = entity
                                            });
            }
            else
            {
                var course = this.courseRepository.OneMatching(new FindCourseById().SetId(processingEntity.CourseId));
                course.CourseTopics.Add(new CourseTopicsCourse
                                            {
                                                CourseId = processingEntity.CourseId,
                                                CourseTopics = courseTopics
                                            });
            }

            return await this.CommitAsync()
                       ? true
                       : throw new DatabaseException("Save exeption");
        }
        public async Task<Course> GetGourse(ISpecification<Course> criteria = null)
        {
            var ret = this.courseRepository.OneMatching(
                filter: criteria,//new FindCourseById().SetId(request.Id),
                includes: new CourseInclude());

            return await Task.FromResult(ret);
        }
        public async Task<IEnumerable<Course>> GetGourses(ISpecification<Course> criteria = null)
        {
            var ret = this.courseRepository.AllMatching(criteria, includes: new CourseInclude());
            return await Task.FromResult(ret);
        }

    }
}