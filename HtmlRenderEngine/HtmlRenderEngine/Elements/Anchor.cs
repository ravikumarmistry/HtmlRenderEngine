using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlRenderEngine.Abstract;

namespace HtmlRenderEngine.Elements
{
    public class Anchor:AElement
    {
        private String ElementSpacificAttributes = "";

        public Anchor(string Link,string Text)
        {
            this.element = "a";
            this.attributes = "href='"+Link+"'";
            this.text = Text;
        }

        #region ##Override Baseclass Methods

        public override string Render()
        {
            foreach (String attr in ElementSpacificAttributes.Split(' '))
            {
                this.Attributes((!String.IsNullOrWhiteSpace(attr)) ? attr : "");
            }
            return base.Render();
        }
        public override string GetInnerHTML()
        {
            
            return base.GetInnerHTML();
        }

        public override Anchor ID(String id)
        {
            base.ID(id);
            return this;
        }
        public override Anchor Text(string text)
        {
            base.Text(text);
            return this;
        }
        public override Anchor AddChild(AElement child)
        {
            base.AddChild(child);
            return this;
        }
        public override Anchor Classes(params String[] clss)
        {
            base.Classes(clss);
            return this;
        }
        public override Anchor RemoveClasses(params String[] clss)
        {
            base.RemoveClasses();
            return this;
        }
        public override Anchor Attributes(params String[] attrs)
        {
            base.Attributes(attrs);
            return this;
        }
        public override Anchor RemoveAttributes(params String[] attrs)
        {
            base.RemoveAttributes(attrs);
            return this;
        }
        public override Anchor Child(int index)
        {
            base.Child(index);
            return this;
        }
        public override Anchor Child(string id)
        {
            base.Child(id);
            return this;
        }
        public override Anchor Child()
        {
            base.Child();
            return this;
        }

        #region ##Access Attribute
        public override Anchor AccessKeyAttr(char key)
        {
            base.AccessKeyAttr(key);
            return this;
        }
        public override Anchor AccessKeyAttrRemove()
        {
            base.AccessKeyAttrRemove();
            return this;
        }
        #endregion
        #region ##Content Editable Attribute
        public override Anchor ContentEditableAttr(bool flag)
        {
            base.ContentEditableAttr(flag);
            return this;
        }
        public override Anchor ContentEditableAttrRemove()
        {
            base.ContentEditableAttrRemove();
            return this;
        }
        #endregion
        #region ##Dir Attribute
        public override Anchor DirAttr(DirOption dirOptions)
        {
            base.DirAttr(dirOptions);
            return this;
        }
        public override Anchor DirAttrRemove()
        {
            base.DirAttrRemove();
            return this;
        }
        #endregion
        #region ##Draggable Attribute
        public override Anchor DraggableAttr(bool flag)
        {
            base.DraggableAttr(flag);
            return this;
        }
        public override Anchor DraggableAttrRemove()
        {
            base.DraggableAttrRemove();
            return this;
        }
        #endregion
        #region ##Drop Zone Attribute
        public override Anchor DropZoneAttr(DropZoneOption dropZoneOptions)
        {
            base.DropZoneAttr(dropZoneOptions);
            return this;
        }
        public override Anchor DropZoneAttrRemove()
        {
            base.DropZoneAttrRemove();
            return this;
        }
        #endregion
        #region ##Hidden Attribute
        public override Anchor HiddenAttr()
        {
            base.HiddenAttr();
            return this;
        }
        public override Anchor HiddenAttrRemove()
        {
            base.HiddenAttrRemove();
            return this;
        }
        #endregion
        #region ##Lang Attribute
        public override Anchor LangKeyAttr(string languageCode)
        {
            base.LangKeyAttr(languageCode);
            return this;
        }
        public override Anchor LangKeyAttrRemove()
        {
            base.LangKeyAttrRemove();
            return this;
        }
        #endregion
        #region ##Spell Check Attribute
        public override Anchor spellCheckAttr(bool flag)
        {
            base.spellCheckAttr(flag);
            return this;
        }
        public override Anchor spellCheckAttrRemove()
        {
            spellCheckAttrRemove();
            return this;
        }
        #endregion
        #region ##Style Attribute
        public override Anchor StyleAttr(string styleDefinitions)
        {
            base.StyleAttr(styleDefinitions);
            return this;
        }
        public override Anchor StyleAttrRemove()
        {
            base.StyleAttrRemove();
            return this;
        }
        #endregion
        #region ##Tab Index  Attribute
        public override Anchor TabIndexAttr(int number)
        {
            base.TabIndexAttr(number);
            return this;
        }
        public override Anchor TabIndexAttrRemove()
        {
            base.TabIndexAttrRemove();
            return this;
        }
        #endregion
        #region ##Title Attribute
        public override Anchor TitleAttr(string text)
        {
            base.TitleAttr(text);
            return this;
        }
        public override Anchor TitleAttrRemove()
        {
            base.TitleAttrRemove();
            return this;
        }
        #endregion
        
        #endregion

        #region ##Target Attribute
        public enum TargetOption { Blank, Parent, Self, Top }
        private List<String> LTargetOption = new List<String> { "_blank", "_parent", "_self", "_top" };
        public Anchor TargetAttr(TargetOption targetOptions)
        {
            String pattern = "(target='[\\S]+'|target='')";
            ElementSpacificAttributes = Regex.Replace(ElementSpacificAttributes, pattern, "");
            ElementSpacificAttributes = " " + "target='" + LTargetOption[(int)targetOptions] + "'";
            return this;
        }
        public Anchor TargetAttrRemove()
        {
            String pattern = "(target='[\\S]+'|target='')";
            ElementSpacificAttributes = Regex.Replace(ElementSpacificAttributes, pattern, "");
            return this;
        }
        #endregion
        #region ##Rel Attribute
        public enum RelOption { Alternate, Author, Bookmark, Help, License, Next, Nofollow, Noreferrer, Prefetch, Prev, Search, Tag }
        private List<String> LRelOption = new List<String> { "alternate", "author", "bookmark", "help", "license", "next", "nofollow", "noreferrer", "prefetch", "prev", "search", "tag" };
        public Anchor RelAttr(RelOption relOptions)
        {
            String pattern = "(rel='[\\S]+'|rel='')";
            ElementSpacificAttributes = Regex.Replace(ElementSpacificAttributes, pattern, "");
            ElementSpacificAttributes = " " + "rel='" + LTargetOption[(int)relOptions] + "'";
            return this;
        }
        public Anchor RelAttrRemove()
        {
            String pattern = "(rel='[\\S]+'|rel='')";
            ElementSpacificAttributes = Regex.Replace(ElementSpacificAttributes, pattern, "");
            return this;
        }
        #endregion
    }
}
