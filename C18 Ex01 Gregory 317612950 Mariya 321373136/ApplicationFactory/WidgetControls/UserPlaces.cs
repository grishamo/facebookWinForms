using FacebookWrapper.ObjectModel;
using System.Collections.Generic;
using System.Drawing;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public class UserPlaces : Widget
    {
        List<PlaceCategory> m_allCategories = new List<PlaceCategory>();

        protected User FbUser { get; set; }

        public UserPlaces()
        {
            WidgetName = "UserPlaces";
            WidgetTitle = "Your Places";
            AutoSize = true;
            MaximumSize = new Size(0, 390);

            WidgetContainer.AutoScroll = true;
            WidgetContainer.MaximumSize = new Size(1000, 0);
        }

        public string UserName
        {
            get
            {
                return FbUser.FirstName;
            }
            set
            {
                WidgetTitle = value + "'s Places";
            }
        }

        public override void Update(params object[] args)
        {
            ClearWidgetContainer(m_allCategories);
            if (args.Length > 0)
            {
                if (FbUser == null)
                {
                    FbUser = Utils.GetParam<User>(args) as User;
                }

                UserName = FbUser.FirstName;
                m_allCategories = buildCategories(FbUser.Checkins);
                displayPlaces(m_allCategories);
            }
        }

        public virtual void UpdatePlaces(object i_FbUser, object i_FbUser2)
        {
            FbUser = i_FbUser as User;
            Update(FbUser);
        }

        public PlaceCategory FindCategoryByName(string i_CategoryName)
        {
            PlaceCategory foundCategory = null;

            foreach (PlaceCategory category in m_allCategories)
            {
                if (category.CategoryName == i_CategoryName)
                {
                    foundCategory = category;
                    break;
                }
            }

            return foundCategory;
        }

        protected List<PlaceCategory> buildCategories(FacebookObjectCollection<Checkin> i_FbUserCheckins)
        {
            List<PlaceCategory> allCategories = new List<PlaceCategory>();

            foreach (Checkin checkin in i_FbUserCheckins)
            {
                Page currentPlace = checkin.Place;
                PlaceCategory currentCategory;
                bool isCategoryExist = allCategories.Exists(Category => Category.CategoryName == currentPlace.Category);
                
                if (!isCategoryExist)
                {
                    currentCategory = new PlaceCategory(currentPlace.Category);
                    allCategories.Add(currentCategory);
                }
                else
                {
                    currentCategory = FindCategoryByName(currentPlace.Category);
                }

                currentCategory.AddFbPage(currentPlace);

            };

            // Mock Data
            // TODO: remove after debugging
            allCategories = mockData();

            return allCategories;
        }

        protected void displayPlaces(List<PlaceCategory> allCategories)
        {
            foreach (PlaceCategory category in allCategories)
            {
                WidgetContainer.Controls.Add(category);
            }

        }

        private List<PlaceCategory> mockData()
        {
            List<PlaceCategory> allCategories = new List<PlaceCategory>();

            PlaceCategory mockCategory = new PlaceCategory("Bars");
            for (int i = 0; i < 10; i++)
            {
                Place mockPage = new Place(
                "https://scontent.fsdv2-1.fna.fbcdn.net/v/t1.0-1/p200x200/10526090_1500996420186296_4590947557162620097_n.png?_nc_cat=0&oh=a8eb815a522407ac3b176068ab31d283&oe=5BD0BB9F",
                "FREEDOM",
                "https://www.facebook.com/freedombarjerusalem/");

                mockCategory.AddPlace(mockPage);
                allCategories.Add(mockCategory);
            }

            PlaceCategory mockCategory2 = new PlaceCategory("Restorans");
            for (int i = 0; i < 10; i++)
            {
                Place mockPage = new Place(
                "https://scontent.fsdv2-1.fna.fbcdn.net/v/t1.0-1/564764_420623054627489_1533284902_n.jpg?_nc_cat=0&oh=9d9f67fcda93d4636ae35864461d2e4b&oe=5C107377",
                "Shaker",
                "https://www.facebook.com/Shaker-239039062785890/");

                mockCategory2.AddPlace(mockPage);
                allCategories.Add(mockCategory2);
            }

            return allCategories;
        }
    }
}
