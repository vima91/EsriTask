namespace EsriTask.Models
{
    public class PopulationDataAttribute
    {
        public PopulationDataAttribute(string attrib, int population)
        {
            Attrib = attrib;
            Population = population;
        }

        public string Attrib { get; set; }
        public int Population { get; set; }
    }
}