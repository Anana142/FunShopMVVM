using FunShopMVVMTwo.Model;
using FunShopMVVMTwo.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FunShopMVVMTwo.ViewModel
{
	[QueryProperty(nameof(Id_), "id")]
	public class EditProductVM : BaseVM
	{
		private int id_;
		private Product selected;
		private string photoPath;
		private Category selectedCategory;
		private List<Category> listCatigories;
		private int id_1;

		public int Id_ { get => id_1; set { GetSelected(); id_1 = value; } }

		public Product Selected { get => selected; set { selected = value; Signal(); } }
		public string PhotoPath { get => photoPath; set { photoPath = value; Signal(); } }
		public Category SelectedCategory { get => selectedCategory; set { selectedCategory = value; Signal(); } }
		public List<Category> ListCatigories { get => listCatigories; set { listCatigories = value; Signal(); } }


		public CustomCommand Save { get; set; }
		public CustomCommand Back { get; set; }	
		public CustomCommand GetPhoto { get; set; }

        public EditProductVM()
        {
			Save = new CustomCommand(async () =>
			{
				Selected.PathImage = PhotoPath;

				if (SelectedCategory == null)
				{
					await App.Current.MainPage.DisplayAlert("Сообщение", "Необходимо выбрать категорию", "Ок");
					return;
				}

				Selected.IdCategory = SelectedCategory.Id;

				if (Selected.Id == 0)
					DataBase.Instance.Products.Add(Selected);

				else
					DataBase.Instance.Products.Update(Selected);

				DataBase.Instance.SaveChanges();
			});

			Back = new CustomCommand(async() =>
			{
				await Shell.Current.GoToAsync("..");
			});

			GetPhoto = new CustomCommand(() =>
			{
				TakePhotoAsync();
			});
        }

		void GetSelected()
		{
			if (Id_ != 0)
				Selected = DataBase.Instance.Products.FirstOrDefault(s => s.Id == Id_);
			else
				Selected = new Product();

			PhotoPath = Selected.PathImage;

			ListCatigories = DataBase.Instance.Categories.ToList();

		}
		async Task TakePhotoAsync()
		{
			try
			{
				var photo = await MediaPicker.PickPhotoAsync();
				await LoadPhotoAsync(photo);
				Console.WriteLine($"CapturePhotoAsync COMPLETED: {photoPath}");
			}
			catch (FeatureNotSupportedException fnsEx)
			{
				// Feature is not supported on the device
			}
			catch (PermissionException pEx)
			{
				// Permissions not granted
			}
			catch (Exception ex)
			{
				Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
			}
		}
		async Task LoadPhotoAsync(FileResult photo)
		{
			// canceled
			if (photo == null)
			{
				PhotoPath = null;
				return;
			}
			// save the file into local storage
			var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
			using (var stream = await photo.OpenReadAsync())
			using (var newStream = File.OpenWrite(newFile))
				await stream.CopyToAsync(newStream);

			PhotoPath = newFile;
		}

		public void OnAppearing()
		{
			GetSelected();
			SelectedCategory = Selected.Category;
		}
	}
}
