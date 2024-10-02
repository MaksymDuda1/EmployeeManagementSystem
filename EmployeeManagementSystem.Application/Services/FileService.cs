using System.Globalization;
using System.Text;
using CsvHelper;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Domain.Dtos;
using FluentResults;
using MiniExcelLibs;

namespace EmployeeManagementSystem.Application.Services;

public class FileService : IFileService
{
    public async Task<Result<MemoryStream>> ExportToExcel(List<UserDto> users)
    {
        var memoryStream = new MemoryStream();
        await memoryStream.SaveAsAsync(users);
        memoryStream.Seek(0, SeekOrigin.Begin);
        return Result.Ok(memoryStream);
    }

    public async Task<Result<MemoryStream>> ExportToCsv(List<UserDto> users)
    {
        var memoryStream = new MemoryStream();
        await using (var streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(true)))
        await using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
        {
            csvWriter.WriteHeader<UserDto>();
            await csvWriter.NextRecordAsync();

            await csvWriter.WriteRecordsAsync(users);

            await streamWriter.FlushAsync();

            memoryStream.Position = 0;
        }

        return Result.Ok(memoryStream);
    }
}