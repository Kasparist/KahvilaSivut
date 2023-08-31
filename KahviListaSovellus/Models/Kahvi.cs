public class Kahvi
{
    public int Id { get; set; }


    public string? Nimi { get; set; }
    public KahvinKoko Koko { get; set; }
    public bool Laktoositon { get; set; }

    public decimal Hinta { get; set; }
}

public enum KahvinKoko { Small, Medium, Large }