using System.Linq;
using System.Windows.Interactivity;
using Cimbalino.Phone.Toolkit.Behaviors;
using Microsoft.Phone.Controls;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cimbalino.Phone.Toolkit.Tests.Behaviors
{
    [TestClass]
    public class ApplicationBarBehaviorTests
    {
        [UITestMethod]
        public void CanAddIconButtonToApplicationBarBehavior()
        {
            var applicationBarBehavior = new ApplicationBarBehavior();

            applicationBarBehavior.Buttons.Add(new ApplicationBarIconButton()
            {
                Text = "button 1"
            });

            Assert.AreEqual(applicationBarBehavior.InternalApplicationBar.Buttons.Count, 1);
        }

        [UITestMethod]
        public void CanAddMenuItemToApplicationBarBehavior()
        {
            var applicationBarBehavior = new ApplicationBarBehavior();

            applicationBarBehavior.MenuItems.Add(new ApplicationBarMenuItem()
            {
                Text = "menu item 1"
            });

            Assert.AreEqual(applicationBarBehavior.InternalApplicationBar.MenuItems.Count, 1);
        }

        [UITestMethod]
        public void Add5IconButtonsGetsFirst4Visible()
        {
            var applicationBarBehavior = new ApplicationBarBehavior();

            var iconButtons = Enumerable.Range(0, 5)
                .Select(x => new ApplicationBarIconButton()
                {
                    Text = "button " + x
                })
                .ToArray();

            foreach (var iconButton in iconButtons)
            {
                applicationBarBehavior.Buttons.Add(iconButton);
            }

            Assert.AreEqual(applicationBarBehavior.InternalApplicationBar.Buttons.Count, 4);

            for (int buttonIndex = 0; buttonIndex < 4; buttonIndex++)
            {
                var applicationBarButton = (Microsoft.Phone.Shell.ApplicationBarIconButton)applicationBarBehavior.InternalApplicationBar.Buttons[buttonIndex];

                Assert.AreEqual(applicationBarButton.Text, iconButtons[buttonIndex].Text);
            }
        }
    }
}