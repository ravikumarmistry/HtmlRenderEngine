using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlRenderEngine.Abstract
{
    public abstract class AElement
    {
        protected string htmlStart = "<element id class attributes>";
        protected string htmlEnd = "</element>";
        protected string element = "";
        protected string id = "";
        protected String classes = "";
        protected String attributes = "";
        protected List<AElement> childs = new List<AElement>();
        protected AElement parent;
        protected string text = "";

        public virtual string Render()
        {
            htmlEnd = htmlEnd.Replace("element", element);
            htmlStart = htmlStart.Replace("element", element);
            htmlStart = (!String.IsNullOrEmpty(id))? htmlStart.Replace("id", "id=" + id):htmlStart.Replace("id","");
            htmlStart = (!String.IsNullOrEmpty(classes))? htmlStart.Replace("class", "class='"+classes+"'"):htmlStart.Replace("class","");
            htmlStart = (!String.IsNullOrEmpty(attributes)) ? htmlStart.Replace("attributes", attributes) : htmlStart.Replace("attributes", "");

            return htmlStart + text + GetInnerHTML() + htmlEnd;
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

        protected AElement AddChild(AElement child)
        {
            childs.Add(child);
            child.parent = this;
            return this;
        }
        protected AElement Classes(params String[] clss)
        {
            classes += " " + String.Join(" ", clss);
            return this;
        }
        protected AElement Attributes(params String[] attrs)
        {
            attributes += " " + String.Join(" ", attrs);
            return this;
        }
        protected AElement ID(String id)
        {
            this.id = id;
            return this;
        }
        protected AElement Text(string text)
        {
            this.text = text;
            return this;
        }

        protected AElement Child(int index)
        {
            return childs[index];
        }
        /// <summary>
        /// Return the child with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected AElement Child(string id)
        {
            foreach (AElement c in childs)
            {
                if (c.id == id)
                    return c;
            }
            return null;
        }
        /// <summary>
        /// Return the last child element
        /// </summary>
        /// <returns></returns>
        protected AElement Child()
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
