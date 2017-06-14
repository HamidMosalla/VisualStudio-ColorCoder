using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorCoder.ColorCoderCore;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Moq;
using Xunit;


namespace ColorCoderTests
{
    public class ColorCoderTaggerTests
    {
        [Fact]
        void GetTagsReturns_EmptyEnumerable_IfSpanCountIsZero()
        {
            var textBufferMock = new Mock<ITextBuffer>();
            var classRegisteryServiceMock = new Mock<IClassificationTypeRegistryService>();

            var sut = new ColorCoderTagger(textBufferMock.Object, classRegisteryServiceMock.Object);

            var result = sut.GetTags(new NormalizedSnapshotSpanCollection());

            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        void GetTagsReturns_EmptyEnumerable_IfCacheIsNotResolved()
        {
            var textBufferMock = new Mock<ITextBuffer>();
            var classRegisteryServiceMock = new Mock<IClassificationTypeRegistryService>();

            var snapShotPoint = new SnapshotPoint(new Mock<ITextSnapshot>().Object, 0);
            var snapshotSpanCollection = new NormalizedSnapshotSpanCollection(new SnapshotSpan(snapShotPoint, snapShotPoint));

            var sut = new ColorCoderTagger(textBufferMock.Object, classRegisteryServiceMock.Object);

            var result = sut.GetTags(snapshotSpanCollection);

            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

    }
}
