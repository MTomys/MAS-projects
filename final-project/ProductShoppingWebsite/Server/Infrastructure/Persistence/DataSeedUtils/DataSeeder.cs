using ProductShoppingWebsite.Shared.Entities;

namespace ProductShoppingWebsite.Server.Infrastructure.Persistence.DataSeedUtils
{
    public static class DataSeeder
    {
        public static readonly List<Report> ReportsForDataSeeding = new()
        {
            new Report
            {
                ReportId = 1,
                UniqueReportIdentificator = 431,
                ReportDescription = "The seller was notoriously scamming",
                ReportDate = new DateTime(2021,5,20),
                IssuerId = 1,
                ReportedSellerId = 1
            },
            new Report
            {

                ReportId = 2,
                UniqueReportIdentificator = 405982,
                ReportDescription = "Scamming",
                ReportDate = new DateTime(2022,3,20),
                IssuerId = 2,
                ReportedSellerId = 1
            },
            new Report
            {
                ReportId = 3,
                UniqueReportIdentificator = 543235,
                ReportDescription = "Product not the same as advertised",
                ReportDate = new DateTime(2021,4,20),
                IssuerId = 3,
                ReportedSellerId = 1

            },
            new Report
            {
                ReportId = 4,
                UniqueReportIdentificator = 5624452,
                ReportDescription = "No order came...",
                ReportDate = new DateTime(2021,1,25),
                IssuerId = 1,
                ReportedSellerId = 2

            },
            new Report
            {
                ReportId = 5,
                UniqueReportIdentificator = 321235,
                ReportDescription = "No",
                ReportDate = new DateTime(2021,2,10),
                IssuerId = 2,
                ReportedSellerId = 2

            },
            new Report
            {
                ReportId = 6,
                UniqueReportIdentificator = 7568,
                ReportDescription = "Annoying seller",
                ReportDate = new DateTime(2021,5,26),
                IssuerId = 3,
                ReportedSellerId = 3

            },
            new Report
            {
                ReportId = 7,
                UniqueReportIdentificator = 98689,
                ReportDescription = "Didnt deliver on time",
                ReportDate = new DateTime(2021,5,24),
                IssuerId = 1,
                ReportedSellerId = 3

            },
            new Report
            {
                ReportId = 8,
                UniqueReportIdentificator = 1958523,
                ReportDescription = "Took the cash and left, no response so far...",
                ReportDate = new DateTime(2021,5,29),
                IssuerId = 2,
                ReportedSellerId = 3
            },
        };

        public static readonly List<Seller> SellersForDataSeeding = new()
        {
            new Seller
            {
                SellerId = 1,
                UniqueSellerIdentificator = 95487,
                SellerNickname = "John Doe",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1999, 12, 24),
                Email = "johnDoe@gmail.com",
                PhoneNumber = "987538223",
                Address = "22nd Straight street, NY",
                BankAccountNumber = "888969040328",
                IsAuthorized = true,
                IsArchived = false,
                IsBanned = false,
            },
            new Seller
            {
                SellerId = 2,
                UniqueSellerIdentificator = 5789432,
                SellerNickname = "Michael Tomys",
                FirstName = "Michael",
                LastName = "Tomys",
                BirthDate = new DateTime(2000, 11, 24),
                Email = "michaltomys@wp.com",
                PhoneNumber = "565723143",
                Address = "Zlota 44, Warsaw",
                BankAccountNumber = "66654334883029",
                IsAuthorized = true,
                IsArchived = false,
                IsBanned = false,
            },
            new Seller
            {
                SellerId = 3,
                UniqueSellerIdentificator = 6587390,
                SellerNickname = "Adam Smith",
                FirstName = "Adam",
                LastName = "Smith",
                BirthDate = new DateTime(1998, 5, 15),
                Email = "AdamSmith@gmail.com",
                PhoneNumber = "689605342",
                Address = "Valley of warrios 1, Uganda",
                BankAccountNumber = "59838053298320",
                IsAuthorized = true,
                IsArchived = false,
                IsBanned = false,
            },
            new Seller
            {
                SellerId = 4,
                UniqueSellerIdentificator = 3421697,
                SellerNickname = "Sebastian Fors",
                FirstName = "Sebastian",
                LastName = "Fors",
                BirthDate = new DateTime(1990, 6, 24),
                Email = "forsen@gmail.com",
                PhoneNumber = "445634932",
                Address = "snus street 5, Stockholm, Sweden",
                BankAccountNumber = "914827048712",
                IsAuthorized = true,
                IsArchived = false,
                IsBanned = true,
            },
            new Seller
            {
                SellerId = 5,
                UniqueSellerIdentificator = 87678402,
                SellerNickname = "Antoni Smolinski",
                FirstName = "Antoni",
                LastName = "Smolinski",
                BirthDate = new DateTime(2000, 1, 5),
                Email = "antoni.smolinski@gmail.com",
                PhoneNumber = "867339224",
                Address = "Polna 5, Konstancin-Jeziorna, Poland",
                BankAccountNumber = "16555444656393",
                IsAuthorized = true,
                IsArchived = false,
                IsBanned = false,
            }
        };

    }
}
