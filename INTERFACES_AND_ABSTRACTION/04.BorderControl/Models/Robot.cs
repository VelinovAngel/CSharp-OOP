using System;

using _04.BorderControl.Interfaces;

namespace _04.BorderControl.Models
{
    public class Robot : IIdentificable
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get => this.model; private set => this.model = value; }

        public string Id { get => this.id; private set => this.id = value; }
    }
}
