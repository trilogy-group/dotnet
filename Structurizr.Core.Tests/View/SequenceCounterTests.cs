using Xunit;

namespace Structurizr.Core.Tests
{
    
    public class SequenceCounterTests
    {

        [Fact]
        public void Test_increment_IncrementsTheCounter_WhenThereIsNoParent()
        {
            SequenceCounter counter = new SequenceCounter();
            Assert.Equal("0", counter.AsString());

            counter.Increment();
            Assert.Equal("1", counter.AsString());

            counter.Increment();
            Assert.Equal("2", counter.AsString());
        }

        [Fact]
        public void Test_counter_WhenThereIsOneParent()
        {
            SequenceCounter parent = new SequenceCounter();
            parent.Increment();
            Assert.Equal("1", parent.AsString());

            SequenceCounter child = new SequenceCounter(parent);
            child.Increment();
            Assert.Equal("1.1", child.AsString());

            child.Increment();
            Assert.Equal("1.2", child.AsString());
        }

        [Fact]
        public void Test_counter_WhenThereAreTwoParents()
        {
            SequenceCounter parent = new SequenceCounter();
            parent.Increment();
            Assert.Equal("1", parent.AsString());

            SequenceCounter child = new SequenceCounter(parent);
            child.Increment();
            Assert.Equal("1.1", child.AsString());

            SequenceCounter grandchild = new SequenceCounter(child);
            grandchild.Increment();
            Assert.Equal("1.1.1", grandchild.AsString());

            grandchild.Increment();
            Assert.Equal("1.1.2", grandchild.AsString());
        }

    }
}
