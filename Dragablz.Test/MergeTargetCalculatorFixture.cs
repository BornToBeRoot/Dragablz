using System.Windows;
using System.Windows.Controls;
using NUnit.Framework;

namespace Dragablz.Tests
{
    [TestFixture]
    public class MergeTargetCalculatorFixture
    {
        private static readonly Rect Items = new Rect(100, 10, 300, 30);
        private static readonly Rect Panel = new Rect(50, 10, 800, 30);

        [Test]
        public void HeaderItemsAreaUsesItemsBounds()
        {
            var result = MergeTargetCalculator.GetBounds(Items, Panel, MergeTargetArea.HeaderItems, Orientation.Horizontal, 0);

            Assert.That(result, Is.EqualTo(Items));
        }

        [Test]
        public void HeaderPanelAreaUsesPanelBounds()
        {
            var result = MergeTargetCalculator.GetBounds(Items, Panel, MergeTargetArea.HeaderPanel, Orientation.Horizontal, 0);

            Assert.That(result, Is.EqualTo(Panel));
        }

        [Test]
        public void HeaderPanelAreaFallsBackToItemsBoundsWithoutPanel()
        {
            var result = MergeTargetCalculator.GetBounds(Items, null, MergeTargetArea.HeaderPanel, Orientation.Horizontal, 0);

            Assert.That(result, Is.EqualTo(Items));
        }

        [Test]
        public void HorizontalFixedItemsMoveLeftEdge()
        {
            var result = MergeTargetCalculator.GetBounds(Items, Panel, MergeTargetArea.HeaderItems, Orientation.Horizontal, 80);

            Assert.That(result, Is.EqualTo(new Rect(180, 10, 220, 30)));
        }

        [Test]
        public void HeaderPanelAreaExcludesFixedItemsAndAreaBeforeThem()
        {
            var result = MergeTargetCalculator.GetBounds(Items, Panel, MergeTargetArea.HeaderPanel, Orientation.Horizontal, 20);

            Assert.That(result, Is.EqualTo(new Rect(120, 10, 730, 30)));
        }

        [Test]
        public void VerticalFixedItemsMoveTopEdge()
        {
            var items = new Rect(0, 100, 30, 300);
            var panel = new Rect(0, 50, 30, 800);

            var result = MergeTargetCalculator.GetBounds(items, panel, MergeTargetArea.HeaderPanel, Orientation.Vertical, 80);

            Assert.That(result, Is.EqualTo(new Rect(0, 180, 30, 670)));
        }

        [Test]
        public void FixedItemsBeyondAreaGiveEmptyWidth()
        {
            var result = MergeTargetCalculator.GetBounds(Items, null, MergeTargetArea.HeaderItems, Orientation.Horizontal, 1000);

            Assert.That(result.Width, Is.EqualTo(0));
        }

        [Test]
        public void InflateGrowsAllSides()
        {
            var result = MergeTargetCalculator.Inflate(new Rect(10, 10, 20, 20), 5);

            Assert.That(result, Is.EqualTo(new Rect(5, 5, 30, 30)));
        }

        [TestCase(-20, 0, 300, 0)]
        [TestCase(150, 0, 300, 150)]
        [TestCase(900, 0, 300, 300)]
        [TestCase(10, 80, 300, 80)]
        [TestCase(900, 80, 50, 80)]
        [TestCase(900, 0, 0, 0)]
        public void ClampsInsertPosition(double desired, double fixedEnd, double lastEnd, double expected)
        {
            Assert.That(MergeTargetCalculator.ClampInsertPosition(desired, fixedEnd, lastEnd), Is.EqualTo(expected));
        }
    }
}
