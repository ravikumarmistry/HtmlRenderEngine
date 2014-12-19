using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HtmlRenderEngine.Abstract
{
    public abstract class AElement
    {
        protected string htmlStart = "<element id='' attributes class='' >";
        protected string htmlEnd = "</element>";
        protected string element = "";
        protected string id = "";
        private string preId = "";
        protected String classes = "";
        private String preClasses = "";
        protected String attributes = "";
        private String preAttributes = "attributes";
        protected List<AElement> childs = new List<AElement>();
        protected AElement parent;
        protected string text = "";
        string idReplacePattern = @"id='.*'";
        string classReplacePattern = @"class='.*'";
        string attributesReplacePattern = @"attributes";

        public virtual string Render()
        {
            htmlEnd = htmlEnd.Replace("element", element);
            htmlStart = htmlStart.Replace("element", element);
            htmlStart = (preId != id) ? htmlStart.Replace("id='"+preId+"'", "id='" + id + "'") : htmlStart.Replace("id='" + id + "'", "id=''");
            htmlStart = (preClasses != classes) ? Regex.Replace(htmlStart, classReplacePattern, "class='" + classes + "'", RegexOptions.Multiline) : htmlStart;
            htmlStart = (preAttributes != attributes) ? htmlStart.Replace(preAttributes, attributes) : htmlStart;
            preId = id;
            preClasses = classes;
            preAttributes = attributes;
            return htmlStart.Replace("id=''", "").Replace("class=''", "").Replace("attributes","") + text + GetInnerHTML() + htmlEnd;
        }
        public virtual string GetInnerHTML()
        {
            string innerHtml = "";
            foreach (AElement row in childs)
            {
                innerHtml += row.Render();
            }
            return innerHtml;
        }
        public virtual AElement ID(String id)
        {
            this.id = id;
            return this;
        }
        public virtual AElement Text(string text)
        {
            this.text = text;
            return this;
        }
        public virtual AElement AddChild(AElement child)
        {
            childs.Add(child);
            child.parent = this;
            return this;
        }

        public virtual AElement Classes(params String[] clss)
        {
            foreach (string  c in clss)
            {
                if (!classes.Contains(c))
                    classes += " " + c;
            }
            return this;
        }
        public virtual AElement RemoveClasses(params String[] clss)
        {
            foreach (string c in clss)
            {
               classes = classes.Replace(c+" ","");
            }
            return this;
        }

        public virtual AElement Attributes(params String[] attrs)
        {
            foreach (string a in attrs)
            {
                if (!attributes.Contains(a))
                    attributes += " " + a;
            }
            return this;
        }
        public virtual AElement RemoveAttributes(params String[] attrs)
        {
            foreach (string a in attrs)
            {
                String pattern = "("+a+"='[\\S]+'|"+a+"='')";
                attributes = Regex.Replace(attributes, pattern, "");
            }
            return this;
        }

        #region ##Access Attribute
        public virtual AElement AccessKeyAttr(char key)
        {
            String pattern = "(accesskey='[\\S]+'|accesskey='')";
            attributes = Regex.Replace(attributes, pattern, "");
            attributes = " " + "accesskey='" + key + "'";
            return this;
        }
        public virtual AElement AccessKeyAttrRemove()
        {
            String pattern = "(accesskey='[\\S]+'|accesskey='')";
            attributes = Regex.Replace(attributes, pattern, "");
            return this;
        }
        #endregion
        #region ##Content Editable Attribute
        public virtual AElement ContentEditableAttr(bool flag)
        {
            String pattern = "(contenteditable='[\\S]+'|contenteditable='')";
            attributes = Regex.Replace(attributes, pattern, "");
            attributes = " " + "contenteditable='" + ((flag)?"true":"false") + "'";
            return this;
        }
        public virtual AElement ContentEditableAttrRemove()
        {
            String pattern = "(contenteditable='[\\S]+'|contenteditable='')";
            attributes = Regex.Replace(attributes, pattern, "");
            return this;
        }
        #endregion
        #region ##Dir Attribute
        public enum DirOption { LeftToRight, RightToLeft, Auto }
        private List<String> LDirOption = new List<String> { "ltr", "rtl", "auto" };
        public virtual AElement DirAttr(DirOption dirOptions)
        {
            String pattern = "(dir='[\\S]+'|dir='')";
            attributes = Regex.Replace(attributes, pattern, "");
            attributes = " " + "dir='" + LDirOption[(int)dirOptions] + "'";
            return this;
        }
        public virtual AElement DirAttrRemove()
        {
            String pattern = "(dir='[\\S]+'|dir='')";
            attributes = Regex.Replace(attributes, pattern, "");
            return this;
        }
        #endregion
        #region ##Draggable Attribute
        public virtual AElement DraggableAttr(bool flag)
        {
            String pattern = "(draggable='[\\S]+'|draggable='')";
            attributes = Regex.Replace(attributes, pattern, "");
            attributes = " " + "draggable='" + ((flag)?"true":"false") + "'";
            return this;
        }
        public virtual AElement DraggableAttrRemove()
        {
            String pattern = "(draggable='[\\S]+'|draggable='')";
            attributes = Regex.Replace(attributes, pattern, "");
            return this;
        }
        #endregion
        #region ##Drop Zone Attribute
        public enum DropZoneOption { Copy, Move, Link }
        private List<String> LDropZoneOption = new List<String> { "copy", "move", "link" };
        public virtual AElement DropZoneAttr(DropZoneOption dropZoneOptions)
        {
            String pattern = "(dropzone='[\\S]+'|dropzone='')";
            attributes = Regex.Replace(attributes, pattern, "");
            attributes = " " + "dropzone='" + LDropZoneOption[(int)dropZoneOptions] + "'";
            return this;
        }
        public virtual AElement DropZoneAttrRemove()
        {
            String pattern = "(dropzone='[\\S]+'|dropzone='')";
            attributes = Regex.Replace(attributes, pattern, "");
            return this;
        }
        #endregion
        #region ##Hidden Attribute
        public virtual AElement HiddenAttr()
        {
            String pattern = "(hidden='[\\S]+'|hidden='')";
            attributes = Regex.Replace(attributes, pattern, "");
            attributes = " " + "hidden='" + "hidden" + "'";
            return this;
        }
        public virtual AElement HiddenAttrRemove()
        {
            String pattern = "(hidden='[\\S]+'|hidden='')";
            attributes = Regex.Replace(attributes, pattern, "");
            return this;
        }
        #endregion
        #region ##Lang Attribute
        public virtual AElement LangKeyAttr(string languageCode)
        {
            String pattern = "(lang='[\\S]+'|accesskey='')";
            attributes = Regex.Replace(attributes, pattern, "");
            attributes = " " + "lang='" + languageCode + "'";
            return this;
        }
        public virtual AElement LangKeyAttrRemove()
        {
            String pattern = "(lang='[\\S]+'|lang='')";
            attributes = Regex.Replace(attributes, pattern, "");
            return this;
        }
        #endregion
        #region ##Spell Check Attribute
        public virtual AElement spellCheckAttr(bool flag)
        {
            String pattern = "(spellcheck='[\\S]+'|spellcheck='')";
            attributes = Regex.Replace(attributes, pattern, "");
            attributes = " " + "spellcheck='" + ((flag)?"true":"false") + "'";
            return this;
        }
        public virtual AElement spellCheckAttrRemove()
        {
            String pattern = "(spellcheck='[\\S]+'|spellcheck='')";
            attributes = Regex.Replace(attributes, pattern, "");
            return this;
        }
        #endregion
        #region ##Style Attribute
        public virtual AElement StyleAttr(string styleDefinitions)
        {
            String pattern = "(style='[\\S]+'|style='')";
            attributes = Regex.Replace(attributes, pattern, "");
            attributes = " " + "style='" + styleDefinitions + "'";
            return this;
        }
        public virtual AElement StyleAttrRemove()
        {
            String pattern = "(style='[\\S]+'|style='')";
            attributes = Regex.Replace(attributes, pattern, "");
            return this;
        }
        #endregion
        #region ##Tab Index  Attribute
        public virtual AElement TabIndexAttr(int number)
        {
            String pattern = "(tabindex='[\\S]+'|tabindex='')";
            attributes = Regex.Replace(attributes, pattern, "");
            attributes = " " + "tabindex='" + number + "'";
            return this;
        }
        public virtual AElement TabIndexAttrRemove()
        {
            String pattern = "(tabindex='[\\S]+'|tabindex='')";
            attributes = Regex.Replace(attributes, pattern, "");
            return this;
        }
        #endregion
        #region ##Title Attribute
        public virtual AElement TitleAttr(string text)
        {
            String pattern = "(title='[\\S]+'|title='')";
            attributes = Regex.Replace(attributes, pattern, "");
            attributes = " " + "title='" + text + "'";
            return this;
        }
        public virtual AElement TitleAttrRemove()
        {
            String pattern = "(title='[\\S]+'|title='')";
            attributes = Regex.Replace(attributes, pattern, "");
            return this;
        }
        #endregion
        public virtual AElement Child(int index)
        {
            return childs[index];
        }
        public virtual AElement Child(string id)
        {
            foreach (AElement c in childs)
            {
                if (c.id == id)
                    return c;
            }
            return null;
        }
        public virtual AElement Child()
        {
            if (childs.Count > 0)
                return childs[childs.Count - 1];

            return null;
        }



        //protected virtual AElement RemoveChild(string selector)
        //{
        //    if (selector.Contains("#"))
        //    {
        //        foreach (var child in childs)
        //        {
        //            if (child.id.ToUpper() == selector.ToUpper().Replace("#", ""))
        //            {
        //                childs.Remove(child);
        //            }
        //        }
        //    }
        //    else if (selector.Contains("."))
        //    {
        //        foreach (var child in childs)
        //        {
        //            if (child.classes.ToUpper().Contains(selector.ToUpper().Replace(".", "")))
        //            {
        //                childs.Remove(child);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (var child in childs)
        //        {
        //            if (child.element.ToUpper() == selector.ToUpper())
        //            {
        //                childs.Remove(child);
        //            }
        //        }
        //    }

        //    return this;
        //}
        //protected virtual AElement RemoveAll(string selector)
        //{
        //    childs.Clear();
        //    return this;
        //}
        //protected virtual AElement Remove()
        //{
        //    AElement parrent = this.parent;
        //    parent.RemoveChild(this);
        //    return parent;
        //}
    }
}
