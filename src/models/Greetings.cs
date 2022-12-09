namespace TryConsole {
    public class Greetings {
        private string name;

        public Greetings(string name)
        {
            this.name = name;
        }

        public string hello() {
            return $"Hello, {name}!";
        }
    }
}
