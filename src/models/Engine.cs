namespace MyGame {

    public interface Character {
        bool IsValid(string number);
    }

    public class Enemy : Character
    {
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
            return false;
        }

    }

}