﻿using CsvHelper;
using PizzaHutAPI.Application.Common.Interfaces;
using PizzaHutAPI.Application.Dto;
using PizzaHutAPI.Infrastructure.Files.Maps;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace PizzaHutAPI.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        //public byte[] BuildDistrictsFile(IEnumerable<DistrictDto> cities)
        //{
        //    using var memoryStream = new MemoryStream();
        //    using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
        //    {
        //        using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

        //        csvWriter.Context.RegisterClassMap<DistrictMap>();
        //        csvWriter.WriteRecords(cities);
        //    }

        //    return memoryStream.ToArray();
        //}
    }
}
