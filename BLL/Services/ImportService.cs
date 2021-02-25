using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using BLL.Factories;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UoW;

namespace BLL.Services
{
    public class ImportService : IImportService
    {
        private readonly IFileService _fileService;
        private readonly ICourseInfoUoWFactory _courseRepositoryFactory;

        public ImportService(
            IFileService fileService, 
            ICourseInfoUoWFactory courseRepositoryFactory)
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

                if (uow == null)
                {
                    continue;
                }

                CleanUp(uow);

                foreach (CourseInfoDto dto in dtos[courseName])
                {
                    AddCourseInfo(dto, uow, ref processedItemInfo);
                }

                importInfo.Items.Add(processedItemInfo);
            }

            return importInfo;
        }

        private void AddCourseInfo(CourseInfoDto dto, ICourseInfoUnitOfWork uow, ref ProcessedItemModel processedItemInfo)
        {
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

        private void CleanUp(ICourseInfoUnitOfWork uow)
        {
            IEnumerable<CourseInfo> courseInfos = uow
                .CourseInfos
                .GetAll()
                .ToList();

            foreach (CourseInfo ci in courseInfos)
            {
                uow.CourseInfos.Delete(ci.Id);
            }

            uow.SaveChanges();
        }
    }
}