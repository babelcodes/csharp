namespace MyGame {

    public interface Character {
        bool IsValid(string number);

        string licenseKey {
            get;
        }
    }

    public class Enemy : Character
    {
        public string licenseKey => throw new NotImplementedException();

        public bool IsValid(string number)
        {
            throw new NotImplementedException();
        }
    }

    public class Engine {

        private readonly Character _character;

        public Engine(Character character) {
            _character = character;
        }

        public bool Evaluate(string name) {
            if (_character.IsValid(name)) {
                return true;
            }
            if (_character.licenseKey == "VALID") {
                return true;
            }
            return false;
        }

    }

}