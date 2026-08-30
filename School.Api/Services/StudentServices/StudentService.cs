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

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync(string? name, int? age, string? sortBy, int page, int pageSize)
        {
            var students = await _repository.GetAllStudentsAsync(name, age, sortBy, page, pageSize);
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }
        public async Task<StudentDto?> GetStudentByIdAsync(int id)
        {
            var student = await _repository.GetStudentByIdAsync(id);
            return student == null ? null : _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> CreateStudentAsync(CreateStudentRequest request)
        {
            if (!await _repository.ClassRoomExistAsync(request.CID))
                throw new ArgumentException("This Class doesn't exits");
            var student = _mapper.Map<Student>(request);
            await _repository.CreateStudentAsync(student);
            var withClassRoom = await _repository.GetStudentByIdAsync(student.StudentID);
            return _mapper.Map<StudentDto>(withClassRoom!);
        }

        public async Task<StudentDto?> UpdateStudentAsync(int id, UpdateStudentDto dto)
        {
            var student = await _repository.GetStudentByIdAsync(id);
            if (student == null)
                return null;

            if (!string.IsNullOrWhiteSpace(dto.StudentName))
                student.StudentName = dto.StudentName;

            if (dto.Age.HasValue)
                student.Age = dto.Age.Value;

            if (dto.CID.HasValue)
            {
                if (!await _repository.ClassRoomExistAsync(dto.CID.Value))
                    throw new ArgumentException("The specified class does not exist.");
                student.CID = dto.CID.Value;
            }

            await _repository.SaveChangesAsync();

            var updated = await _repository.GetStudentByIdAsync(id);
            return _mapper.Map<StudentDto>(updated);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _repository.GetStudentByIdAsync(id);
            if (student == null)
                return false;

            await _repository.RemoveStudentAsync(student);
            return true;
        }

    }
}
