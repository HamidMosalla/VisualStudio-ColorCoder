using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace VisualStudio_ColorCoder.ColorCoderCore
{
    public class ProviderCache
    {
        public Workspace Workspace { get; private set; }
        public Document Document { get; private set; }
        public SemanticModel SemanticModel { get; private set; }
        public SyntaxNode SyntaxRoot { get; private set; }
        public ITextSnapshot Snapshot { get; private set; }

        public ProviderCache() { }

        public static async Task<ProviderCache> Resolve(ITextBuffer buffer, ITextSnapshot snapshot)
        {
            var workspace = buffer.GetWorkspace();
            var document = snapshot.GetOpenDocumentInCurrentContextWithChanges();
            if (document == null)
            {
                // Razor cshtml returns a null document for some reason.
                return null;
            }

            // the ConfigureAwait() calls are important,
            // otherwise we'll deadlock VS
            var semanticModel = await document.GetSemanticModelAsync().ConfigureAwait(false);
            var syntaxRoot = await document.GetSyntaxRootAsync().ConfigureAwait(false);
            return new ProviderCache
            {
                Workspace = workspace,
                Document = document,
                SemanticModel = semanticModel,
                SyntaxRoot = syntaxRoot,
                Snapshot = snapshot
            };
        }
    }
}
