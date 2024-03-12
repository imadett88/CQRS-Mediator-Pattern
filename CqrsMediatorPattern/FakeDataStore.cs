namespace CqrsMediatorPattern
{
    public class FakeDataStore
    {
        private static List<Customer> _customers;


        public FakeDataStore()
        {
            _customers = new List<Customer>
            {
                new Customer{ID = 1, Name = "Imad"},
                new Customer{ID = 2, Name = "Hamza"},
                new Customer{ID = 3, Name = "Yasser"},
            };
        }


        public async Task AddCustomer(Customer customer)
        {
            _customers.Add(customer);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers() => await Task.FromResult(_customers);

        public async Task<Customer> GetCustomerById(int id)
        {
            return await Task.FromResult(_customers.Single(c => c.ID == id));
        }

        public async Task EventOccured(Customer customer, string ev)
        {
            _customers.Single(c => c.ID == customer.ID).Name = $"{customer.Name} ev: ${ev}";
            await Task.CompletedTask;
        }


    }
}
