using IdentityService.WebAppMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace IdentityService.WebAppMvc.Controllers
{
    public class UsersController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7024/api");
        HttpClient client;
        public UsersController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public async Task<ActionResult> Index()
        {
            try
            {
                List<UserDetailsViewModel> modelList = new List<UserDetailsViewModel>();
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/Users3");
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    modelList = JsonConvert.DeserializeObject<List<UserDetailsViewModel>>(data);
                }
                return View(modelList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserDetailsViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(client.BaseAddress + "/Users3", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public async Task<ActionResult> Edit(string AplId)
        {

            try
            {
                UserDetailsViewModel model = new UserDetailsViewModel();
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/Users3/" + AplId);
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<UserDetailsViewModel>(data.Substring(1, data.Length - 2));
                }
                return View(model);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserDetailsViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(client.BaseAddress + "/Users3", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public async Task<ActionResult> Delete(string AplId)
        {
            try
            {
                UserDetailsViewModel model = new UserDetailsViewModel();
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/Users3/" + AplId);
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<UserDetailsViewModel>(data.Substring(1, data.Length - 2));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string AplId)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(client.BaseAddress + "/Users3/" + AplId);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
