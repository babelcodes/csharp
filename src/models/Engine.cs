namespace MyGame {

    public interface ILicenseData {
        string licenseKey { get; }
    }

    public interface IServiceInformation {
        ILicenseData license { get; }
    }

    public interface Character {
        bool IsValid(string number);

        // To test mock of property
        string licenseKey {
            get;
        }

        // To test mock of property hierarchy
        IServiceInformation serviceInformation {
            get;
        }
    }

    public class Enemy : Character
    {
        public string licenseKey => throw new NotImplementedException();

        public IServiceInformation serviceInformation => throw new NotImplementedException();

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
            if (_character.serviceInformation.license.licenseKey == "VALID") {
                return true;
            }
            return false;
        }

    }

}