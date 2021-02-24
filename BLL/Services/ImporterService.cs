using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using BLL.Factories;
using BLL.Models;
using DAL.Entities;
using DAL.UoW;

namespace BLL.Services
{
    public class ImporterService : IImporterService
    {
        private readonly IFileService _fileService;
        private readonly ICourseInfoUoWFactory _courseRepositoryFactory;

        public ImporterService(IFileService fileService, ICourseInfoUoWFactory courseRepositoryFactory)
        {
            _fileService = fileService;
            _courseRepositoryFactory = courseRepositoryFactory;
        }

        public ProcessImportInfoModel ProcessImport()
        {
            IDictionary<string, IEnumerable<CourseInfoDto>> dtos = _fileService.GetCourseInfoDtos();

            ProcessImportInfoModel importInfo = new ProcessImportInfoModel();

            if (dtos == null || !dtos.Any())
            {
                return importInfo;
            }

            importInfo.FilesCount = dtos.Count;

            foreach (string courseName in dtos.Keys)
            {
                ProcessedItemModel processedItemInfo = new ProcessedItemModel()
                {
                    Name = courseName
                };

                ICourseInfoUnitOfWork uow = _courseRepositoryFactory.GetUnitOfWork(courseName);

                //var t = uow
                //    .CourseInfos
                //    .GetAll().ToList();
                //foreach (var i in t)
                //{
                //    uow.CourseInfos.Delete(i.Id);
                //}
                //uow.SaveChanges();
                //continue;

                if (uow == null)
                {
                    continue;
                }

                foreach (CourseInfoDto dto in dtos[courseName])
                {
                    ProcessStudent(dto, uow, ref processedItemInfo);
                }

                importInfo.Items.Add(processedItemInfo);
            }

            return importInfo;
        }

        private void ProcessStudent(CourseInfoDto dto, ICourseInfoUnitOfWork uow, ref ProcessedItemModel processedItemInfo)
        {
            CourseInfo existedEntity = uow
                .CourseInfos
                .GetAll(x => x.StudentName == dto.StudentName)?.FirstOrDefault();

            if (existedEntity != null)
            {
                if (existedEntity.StudentScore == dto.StudentScore)
                {
                    return;
                }

                existedEntity.StudentScore = dto.StudentScore;
                existedEntity.ExportedDate = null;
                uow.CourseInfos.Update(existedEntity);

                processedItemInfo.Updated += 1;

                return;
            }

            uow.CourseInfos.Create(new CourseInfo()
            {
                AddedDate = DateTime.Now,
                StudentName = dto.StudentName,
                StudentScore = dto.StudentScore,
                CourseName = dto.CourseName
            });

            processedItemInfo.Added += 1;

            uow.SaveChanges();
        }
    }
}