namespace Praxis.Domain
{
    public class Event
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public DateTime Begin { get; private set; }

        public DateTime End { get; private set; }
    }
}
