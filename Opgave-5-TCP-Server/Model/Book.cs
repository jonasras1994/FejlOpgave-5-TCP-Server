using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Model
{
    public class Book
    {
        private string _title;
        private string _writer;
        private int _pages;
        private string _isbn13;

        public Book()
        {
        }

        public Book(string title, string writer, int pages, string isbn13)
        {
            _title = title;
            _writer = writer;
            _pages = pages;
            _isbn13 = isbn13;
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Writer
        {
            get { return _writer; }
            set { _writer = value; }
        }

        public int Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }

        public string Isbn13
        {
            get { return _isbn13; }
            set { _isbn13 = value; }
        }

        public override string ToString()
        {
            return $"Book title: {Title}, writer: {Writer}, pages: {Pages}, isbn13: {Isbn13}";
        }
    }
}