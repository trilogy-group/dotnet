using Xunit;

namespace Structurizr.Core.Tests
{
    
    public class SequenceNumberTests
    {

        [Fact]
        public void Test_Increment()
        {
            SequenceNumber sequenceNumber = new SequenceNumber();
            Assert.Equal("1", sequenceNumber.GetNext());
            Assert.Equal("2", sequenceNumber.GetNext());
        }

        [Fact]
        public void Test_ChildSequence()
        {
            SequenceNumber sequenceNumber = new SequenceNumber();
            Assert.Equal("1", sequenceNumber.GetNext());

            sequenceNumber.StartChildSequence();
            Assert.Equal("1.1", sequenceNumber.GetNext());
            Assert.Equal("1.2", sequenceNumber.GetNext());

            sequenceNumber.EndChildSequence();
            Assert.Equal("2", sequenceNumber.GetNext());
        }

        [Fact]
        public void Test_ParallelSequences()
        {
            SequenceNumber sequenceNumber = new SequenceNumber();
            Assert.Equal("1", sequenceNumber.GetNext());

            sequenceNumber.StartParallelSequence();
            Assert.Equal("2", sequenceNumber.GetNext());
            sequenceNumber.EndParallelSequence();

            sequenceNumber.StartParallelSequence();
            Assert.Equal("2", sequenceNumber.GetNext());
            sequenceNumber.EndParallelSequence();

            Assert.Equal("2", sequenceNumber.GetNext());
        }

    }
}
