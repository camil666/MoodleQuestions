﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.Reports
{
    public class SupervisorView : View<SupervisorPresenter>, ISupervisorView
    {
        #region Fields

        private DropDownList _userDropDown;

        #endregion

        #region Properties

        public object DropDownDataSource
        {
            get { return _userDropDown.DataSource; }
            set { _userDropDown.DataSource = value; }
        }

        public override Guid SelectedStudentId
        {
            get
            {
                return Guid.Parse(_userDropDown.SelectedItem.Value);
            }
        }

        #endregion

        #region Constructors

        public SupervisorView()
        {
            _userDropDown = new DropDownList()
            {
                DataTextField = "FullName",
                DataValueField = "Id"
            };

            Presenter = new SupervisorPresenter(this);
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            Controls.Add(new LiteralControl(HttpContext.GetGlobalResourceObject("Strings", "AuthorLabelText").ToString()));
            Controls.Add(_userDropDown);
            Controls.Add(new LiteralControl("<br>"));

            base.OnInit(e);

            if (!Page.IsPostBack)
            {
                Presenter.SetupDropDown();
                var students = (DropDownDataSource as IEnumerable<Student>).ToList();
                students.Insert(0, new Student(HttpContext.GetGlobalResourceObject("Strings", "AllStudentsText").ToString(), Guid.Empty));
                DropDownDataSource = students;
                _userDropDown.DataBind();
            }
        }

        #endregion
    }
}