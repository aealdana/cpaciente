namespace Cpaciente.Web.Pages
{
    public interface IPatientService
    {
        Task<List<Patient>> SearchAsync(string? searchTerm);
        Task<Patient?> GetByIdAsync(int id);
        Task<Patient> AddAsync(Patient patient);
        Task<Patient> UpdateAsync(Patient patient);
        Task DeleteAsync(int id);
    }

    // Implementacion de ejemplo en memoria.
    // Reemplazar por llamadas reales a tu API / Entity Framework / etc.
    public class PatientService : IPatientService
    {
        private readonly List<Patient> _patients = new()
    {
        new Patient { Id = 1, FirstName = "Arturo", LastName = "Elias", DocumentNumber = "05083869-8", Phone = "6306-7658", Email = "test1@mail.com" },
        new Patient { Id = 2, FirstName = "Juan", LastName = "Pablo", DocumentNumber = "00004568-1", Phone = "2254-5698", Email = "test2@mail.com" }
    };

        private int _nextId = 3;

        public Task<List<Patient>> SearchAsync(string? searchTerm)
        {
            var query = _patients.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.Trim().ToLower();
                query = query.Where(p =>
                    p.FirstName.ToLower().Contains(term) ||
                    p.LastName.ToLower().Contains(term) ||
                    p.DocumentNumber.ToLower().Contains(term) ||
                    p.Phone.Contains(term));
            }

            return Task.FromResult(query.ToList());
        }

        public Task<Patient?> GetByIdAsync(int id)
            => Task.FromResult(_patients.FirstOrDefault(p => p.Id == id));

        public Task<Patient> AddAsync(Patient patient)
        {
            patient.Id = _nextId++;
            _patients.Add(patient);
            return Task.FromResult(patient);
        }

        public Task<Patient> UpdateAsync(Patient patient)
        {
            var existing = _patients.FirstOrDefault(p => p.Id == patient.Id);
            if (existing is not null)
            {
                var index = _patients.IndexOf(existing);
                _patients[index] = patient;
            }
            return Task.FromResult(patient);
        }

        public Task DeleteAsync(int id)
        {
            var existing = _patients.FirstOrDefault(p => p.Id == id);
            if (existing is not null) _patients.Remove(existing);
            return Task.CompletedTask;
        }
    }
}
