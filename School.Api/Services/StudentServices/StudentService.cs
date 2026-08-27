using AutoMapper;
using School.Api.DTO.Request;
using School.Api.DTO.Response;
using School.Api.Models.Student;
using School.Api.Repository.StudentRepository;

namespace School.Api.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _repository.GetAllStudentsAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto?> GetStudentByIdAsync(int id)
        {
            var student = await _repository.GetStudentByIdAsync(id);
            return student == null ? null : _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> CreateStudentAsync(CreateStudentRequest request)
        {
            var student = _mapper.Map<Student>(request);
            var created = await _repository.CreateStudentAsync(student);
            var withClassRoom = await _repository.GetStudentByIdAsync(created.StudentID);
            return _mapper.Map<StudentDto>(withClassRoom!);
        }

        public async Task<StudentDto?> UpdateStudentAsync(int id, UpdateStudentDto dto)
        {
            var updated = await _repository.UpdateStudentAsync(id, dto);
            if (updated == null)
                return null;

            var withClassRoom = await _repository.GetStudentByIdAsync(id);
            return _mapper.Map<StudentDto>(withClassRoom);
        }

        public Task<bool> DeleteStudentAsync(int id) => _repository.DeleteStudentAsync(id);
    }
}
