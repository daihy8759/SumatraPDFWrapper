using System;
using System.Collections.Generic;
using System.Linq;

namespace SumatraPDF
{
    /// <summary>
    /// Options for a Printer
    /// </summary>
    public class PrintingOptions : IEquatable<PrintingOptions>
    {
        /// <summary>
        /// Creates new <see cref="PrintingOptions"/> instance.
        /// </summary>
        /// <param name="printerName">Name of the printer.</param>
        /// <param name="filePath">Path to the PDF file.</param>
        public PrintingOptions(string printerName, string filePath)
        {
            this.PrinterName = printerName;
            this.FilePath = filePath;
        }

        /// <summary>
        /// Name of the printer (if the printer is network, use network format e.g. "\\printmachine\defaultprinter").
        /// </summary>
        public string PrinterName { get; }

        /// <summary>
        /// Path to the PDF file.
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// Number of copies
        /// </summary>
        public uint? Copies { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as PrintingOptions);
        }

        public virtual bool Equals(PrintingOptions other)
        {
            return other != null &&
                   this.PrinterName == other.PrinterName &&
                   this.FilePath == other.FilePath &&
                   EqualityComparer<uint?>.Default.Equals(this.Copies, other.Copies);
        }

        public override int GetHashCode()
        {
            int hashCode = -1936359086;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.PrinterName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.FilePath);
            hashCode = hashCode * -1521134295 + EqualityComparer<uint?>.Default.GetHashCode(this.Copies);
            return hashCode;
        }

        public override string ToString()
        {
            return string.Join(
                " ",
                new[]
                {
                    "-s",    
                    this.PrinterName.Format(x => $"-print-to \"{x}\""),
                    this.Copies?.ToString().Format(x => $"-print-settings \"{x}x\""),
                    this.FilePath.Format(x => $"\"{x}\""),
                }
                .Where(x => !string.IsNullOrEmpty(x)));
        }
    }
}
