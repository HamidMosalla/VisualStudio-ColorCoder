namespace ColorCoder.ColorCoderCore
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;
    using Microsoft.VisualStudio.Text;
    using System.Threading.Tasks;

    public class ProviderCache
    {
        public Workspace Workspace { get; private set; }
        public Document Document { get; private set; }
        public SemanticModel SemanticModel { get; private set; }
        public SyntaxNode SyntaxRoot { get; private set; }
        public ITextSnapshot Snapshot { get; private set; }

        public static async Task<ProviderCache> ResolveAsync(ITextBuffer buffer, ITextSnapshot snapshot)
        {
            var workspace = buffer.GetWorkspace();
            var document = snapshot.GetOpenDocumentInCurrentContextWithChanges();

            if (document == null) return null;
            
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