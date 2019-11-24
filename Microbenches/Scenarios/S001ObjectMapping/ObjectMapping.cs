using System.Linq;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;

namespace Microbenches.Scenarios.S001ObjectMapping
{
    [MemoryDiagnoser]
    [MarkdownExporter]
    public class ObjectMapping
    {
        private SourceModels.Employee _source;
        private IMapper _mapper;

        [GlobalSetup]
        public void Setup()
        {
            _source = new SourceModels.Employee
            {
                Id = 671378612,
                FirstName = "First",
                LastName = "Last",
                Email = "first.last@example.com",
                DateOfBirth = new System.DateTime(1980, 2, 5),
                YearsOfService = 3,
                Salary = 125478.45m,
                Subordinates = new System.Collections.Generic.List<SourceModels.Employee>
                {
                    new SourceModels.Employee {
                        Id=671378612,
                        FirstName = "Firrrrst",
                        LastName = "Lasssst",
                        Email = "firrrrst.lasssst@example.com",
                        DateOfBirth = new System.DateTime(1986,12,4),
                        YearsOfService=6,
                        Salary = 4567.15m,
                    }
                }
            };

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SourceModels.Employee, TargetModels.Employee>();
            });
            _mapper = configuration.CreateMapper();
        }

        [Benchmark]
        public TargetModels.Employee Json() => JsonConvert.DeserializeObject<TargetModels.Employee>(JsonConvert.SerializeObject(_source));

        [Benchmark]
        public TargetModels.Employee Automapper() => _mapper.Map<TargetModels.Employee>(_source);

        [Benchmark(Baseline = true)]
        public TargetModels.Employee Mapping() => Map(_source);


        private static TargetModels.Employee Map(SourceModels.Employee source)
        {
            if (source == null)
            {
                return null;
            }

            return new TargetModels.Employee
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Email = source.Email,
                DateOfBirth = source.DateOfBirth,
                YearsOfService = source.YearsOfService,
                Salary = source.Salary,
                Subordinates = source.Subordinates?.Select(Map).ToList()
            };
        }
    }
}