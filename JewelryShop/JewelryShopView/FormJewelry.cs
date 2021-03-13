using JewelryShopBusinessLogic.BindingModels;
using JewelryShopBusinessLogic.BuisnessLogics;
using JewelryShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace JewelryShopView
{
    public partial class FormJewelry : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly JewelryLogic logic;

        private int? id;

        private Dictionary<int, (string, int)> jewelryComponents;

        public FormJewelry(JewelryLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }

        private void FormJewelry_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    JewelryViewModel view = logic.Read(new JewelryBindingModel
                    {
                        Id = id.Value
                    })?[0];


                    if (view != null)
                    {
                        textBoxName.Text = view.JewelryName;
                        textBoxPrice.Text = view.Price.ToString();
                        jewelryComponents = view.JewelryComponents;
                        LoadData();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }

            else
            {
                jewelryComponents = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (jewelryComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in jewelryComponents)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormJewelryComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (jewelryComponents.ContainsKey(form.Id))
                {
                    jewelryComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    jewelryComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormJewelryComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = jewelryComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    jewelryComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        jewelryComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (jewelryComponents == null || jewelryComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new JewelryBindingModel
                {
                    Id = id,
                    JewelryName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    JewelryComponents = jewelryComponents
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}