namespace Tenta_advnet_Tintin_Petersson
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Logg_ActivitiesId { get; set; }
        public virtual Logg_Activities Logg_Activities { get; set; }

    }
}