﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン: 16.0.0.0
//  
//     このファイルへの変更は、正しくない動作の原因になる可能性があり、
//     コードが再生成されると失われます。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace RpgGenerator.Generator.PassiveDecoration.Template
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using RpgGenerator.Generator.Utilities;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class PassiveDecorationTemplate : PassiveDecorationTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("// <autogenerated />\r\n#nullable enable\r\nusing System;\r\nusing System.Collections.G" +
                    "eneric;\r\nusing System.Linq;\r\nusing System.Threading.Tasks;\r\nusing RpgGenerator.B" +
                    "asic;\r\n");
            
            #line 15 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	foreach(var import in Root.GetImports()) { 
            
            #line default
            #line hidden
            this.Write("using ");
            
            #line 16 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(import));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 17 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	} 
            
            #line default
            #line hidden
            this.Write("\r\nnamespace ");
            
            #line 19 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Root.SourceType.FullNamespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n");
            
            #line 21 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	var accessibility = Root.SourceType.GetAccessibilityKeyword(); 
            
            #line default
            #line hidden
            this.Write("\t");
            
            #line 22 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(accessibility));
            
            #line default
            #line hidden
            this.Write(" abstract class ");
            
            #line 22 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Root.Decorator.DecorationName));
            
            #line default
            #line hidden
            this.Write("\r\n\t{\r\n");
            
            #line 24 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	foreach(var hook in Root.Decorator.Hooks) { 
            
            #line default
            #line hidden
            this.Write("\t\tpublic virtual Task BeforeEventAsync(");
            
            #line 25 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(hook.EventTypeName.Name));
            
            #line default
            #line hidden
            this.Write(" @event) => Task.CompletedTask;\r\n\t\tpublic virtual Task AfterEventAsync(");
            
            #line 26 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(hook.EventTypeName.Name));
            
            #line default
            #line hidden
            this.Write(" @event) => Task.CompletedTask;\r\n");
            
            #line 27 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	} 
            
            #line default
            #line hidden
            
            #line 28 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	foreach(var modifier in Root.Decorator.Modifiers) { 
            
            #line default
            #line hidden
            this.Write("\t\tpublic virtual ");
            
            #line 29 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modifier.AttributeType));
            
            #line default
            #line hidden
            this.Write(" Modify");
            
            #line 29 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modifier.AttributeName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 29 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modifier.AttributeType));
            
            #line default
            #line hidden
            this.Write(" source) => source;\r\n");
            
            #line 30 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	} 
            
            #line default
            #line hidden
            this.Write("\t}\r\n\r\n\t");
            
            #line 33 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(accessibility));
            
            #line default
            #line hidden
            this.Write(" sealed class ");
            
            #line 33 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Root.Decorator.DecorationName));
            
            #line default
            #line hidden
            this.Write("HookHandler : IPassiveDecoratorHookHandler\r\n\t{\r\n\t\tpublic Task BeforeEventAsync(");
            
            #line 35 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Root.ProviderName));
            
            #line default
            #line hidden
            this.Write(" provider, IBattleEvent @event)\r\n\t\t\t=> RunAsync(provider, p => SelectBefore(p, @e" +
                    "vent));\r\n\t\t\r\n\t\tpublic Task AfterEventAsync(");
            
            #line 38 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Root.ProviderName));
            
            #line default
            #line hidden
            this.Write(" provider, IBattleEvent @event)\r\n\t\t\t=> RunAsync(provider, p => SelectAfter(p, @ev" +
                    "ent));\r\n\r\n\t\tprivate async Task RunAsync(");
            
            #line 41 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Root.ProviderName));
            
            #line default
            #line hidden
            this.Write(" provider, Func<PassiveDecoration, Task> selector)\r\n\t\t{\r\n\t\t\tif (!(provider is ");
            
            #line 43 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Root.ProviderName));
            
            #line default
            #line hidden
            this.Write(")) return;\r\n\r\n\t\t\tforeach (var passiveEffect in provider.GetPassiveDecorations())\r" +
                    "\n\t\t\t{\r\n\t\t\t\tawait selector(passiveEffect);\r\n\t\t\t}\r\n\t\t}\r\n\r\n\t\tprivate Task SelectBef" +
                    "ore(");
            
            #line 51 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Root.Decorator.DecorationName));
            
            #line default
            #line hidden
            this.Write(" passive, IBattleEvent @event) => @event switch\r\n\t\t{\r\n");
            
            #line 53 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	var i = 0; 
            
            #line default
            #line hidden
            
            #line 54 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	foreach(var hook in Root.Decorator.Hooks) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 55 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(hook.EventTypeName.Name));
            
            #line default
            #line hidden
            this.Write(" ev");
            
            #line 55 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(i));
            
            #line default
            #line hidden
            this.Write(" => passive.BeforeEventAsync(ev");
            
            #line 55 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(i));
            
            #line default
            #line hidden
            this.Write("),\r\n");
            
            #line 56 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	i++; 
            
            #line default
            #line hidden
            
            #line 57 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	} 
            
            #line default
            #line hidden
            this.Write("\t\t\t_ => Task.CompletedTask,\r\n\t\t};\r\n\r\n\t\tprivate Task SelectAfter(");
            
            #line 61 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Root.Decorator.DecorationName));
            
            #line default
            #line hidden
            this.Write(" passive, IBattleEvent @event) => @event switch\r\n\t\t{\r\n");
            
            #line 63 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	var j = 0; 
            
            #line default
            #line hidden
            
            #line 64 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	foreach(var hook in Root.Decorator.Hooks) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 65 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(hook.EventTypeName.Name));
            
            #line default
            #line hidden
            this.Write(" ev");
            
            #line 65 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(j));
            
            #line default
            #line hidden
            this.Write(" => passive.AfterEventAsync(ev");
            
            #line 65 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(j));
            
            #line default
            #line hidden
            this.Write("),\r\n");
            
            #line 66 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	j++; 
            
            #line default
            #line hidden
            
            #line 67 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	} 
            
            #line default
            #line hidden
            this.Write("\t\t\t_ => Task.CompletedTask,\r\n\t\t};\r\n\t}\r\n\r\n");
            
            #line 72 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	foreach(var attribute in Root.FinalAttribute) {  
            
            #line default
            #line hidden
            
            #line 73 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
		var attrName = attribute.AttributeTypeName.Name; 
            
            #line default
            #line hidden
            this.Write("\t");
            
            #line 74 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(accessibility));
            
            #line default
            #line hidden
            this.Write(" sealed class Final");
            
            #line 74 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attrName));
            
            #line default
            #line hidden
            this.Write("\r\n\t{\r\n\t\tprivate readonly ");
            
            #line 76 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attrName));
            
            #line default
            #line hidden
            this.Write(" _baseAttribute;\r\n\t\tprivate readonly ");
            
            #line 77 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Root.ProviderName));
            
            #line default
            #line hidden
            this.Write(" _provider;\r\n\r\n\t\tpublic Final");
            
            #line 79 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attrName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 79 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attrName));
            
            #line default
            #line hidden
            this.Write(" baseAttribute, ");
            
            #line 79 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Root.ProviderName));
            
            #line default
            #line hidden
            this.Write(" provider)\r\n\t\t{\r\n\t\t\t_baseAttribute = baseAttribute;\r\n\t\t\t_provider = provider;\r\n\t\t" +
                    "}\r\n\r\n");
            
            #line 85 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
		foreach(var member in attribute.Members) { 
            
            #line default
            #line hidden
            this.Write("\t\tpublic ");
            
            #line 86 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(member.TypeName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 86 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(member.PropertyName));
            
            #line default
            #line hidden
            this.Write(" => Aggregate(_baseAttribute.");
            
            #line 86 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(member.PropertyName));
            
            #line default
            #line hidden
            this.Write(", p => p.Modify");
            
            #line 86 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(member.PropertyName));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 87 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
		} 
            
            #line default
            #line hidden
            this.Write("\r\n\t\tprivate T Aggregate<T>(T source, Func<");
            
            #line 89 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Root.DecorationName));
            
            #line default
            #line hidden
            this.Write(", Func<T, T>> getModifier)\r\n\t\t{\r\n\t\t\treturn _provider.GetPassiveDecorations()\r\n\t\t\t" +
                    "\t.Aggregate(source, (arg1, effect) => getModifier.Invoke(effect).Invoke(arg1));\r" +
                    "\n\t\t}\r\n\t}\r\n");
            
            #line 95 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
	} 
            
            #line default
            #line hidden
            this.Write("\r\n\t");
            
            #line 97 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(accessibility));
            
            #line default
            #line hidden
            this.Write(" interface ");
            
            #line 97 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Root.ProviderName));
            
            #line default
            #line hidden
            this.Write(" : IPassiveDecorationProviderBase\r\n\t{\r\n\t\tIEnumerable<");
            
            #line 99 "D:\Naohiro\Documents\Repos2\Tools\RpgGenerator\RpgGenerator.Generator\PassiveDecoration\Template\PassiveDecorationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Root.DecorationName));
            
            #line default
            #line hidden
            this.Write("> GetPassiveDecorations();\r\n\t}\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class PassiveDecorationTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
