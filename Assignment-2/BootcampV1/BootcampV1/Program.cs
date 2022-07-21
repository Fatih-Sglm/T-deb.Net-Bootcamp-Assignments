using BootcampV1.Concrete;

namespace BootcampV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Önce Enginner ve accountant Objelerini Oluşturuyoruz base classta istediğimiz Name , Salary , Age ve Job değişkenlerini  Objelere dışardan atıyoruz;
            Programmer programmer = new Programmer("Fatih", 8000, 24, "Enginner");
            Accountant accountant = new Accountant("Ahmet", 5000, 29, "Encounter");

            //sadece o classa özgü olan değişkenlere burada istediğmiz değerleri atıyoruz. 
            programmer.Know_Programming_languages = "C# , Python";
            accountant.KnowingEncounterPrograms = "Atia , Bilsoft , Datasoft";

            //Burda Objeler için yazdığımız özellik metodunu çağırıyoruz.
            programmer.GetEmployeeInformation();
            accountant.GetEmployeeInformation();
            //Burda Maaşına zam vereceğimiz metoda zam değerini yüzde olarak girip objenin Salary değerini güncelliyoruz
            programmer.salary_raise(50);
            accountant.salary_raise(25);
            //Maaşı değerini update ettikten sonra Özellik bigilerini tekar yazdırıyoz
            programmer.GetEmployeeInformation();
            accountant.GetEmployeeInformation();
        }
    }
}
