namespace NutriVie.ViewModel
{
    public class RecetteInfoVM
    {
        public string Nom { get; set; }
        public int NombreIngredients { get; set; }
        public int TempsTotal { get; set; }
        public string Statut { get; set; }
    }
    public class RecetteCategorieVM
    {
        public string NomCategorie { get; set; }
        public List<RecetteInfoVM> Recettes { get; set; } = new List<RecetteInfoVM>();
    }
}
