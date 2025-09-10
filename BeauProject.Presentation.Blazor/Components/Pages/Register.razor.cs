﻿using BeauProject.Identity.Application.DTOs.User;
using BeauProject.Shared.Classes;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace BeauProject.Presentation.Blazor.Components.Pages
{
    public partial class Register
    {
        byte[]? profileImage;
        CreateUserDto createUserDto = new();
        List<ImageFile> filesBase64 = new List<ImageFile>();
        async Task RegisterUser()
        {
            var result = await _authService.RegisterAsync(createUserDto);
            if (result != null && result.Data)
            {
                await _js.InvokeVoidAsync("showSnackbar", "ثبت نام با موفقیت انجام شد. 👍");
                Thread.Sleep(1000);
                await _authService.LoginAsync(createUserDto.UserName, createUserDto.Password);
                _navigator.NavigateTo("/dashboard");
            }
            else
            {
                string text = "";
                string messages = $"<ul>x</ul>";
                if (result == null)
                    text = "نام کاربری و رمز عبور نامعتبر است. 😔";
                else
                {
                    foreach (var item in result.Error)
                    {
                        text += $"<li>⛔ {item}</li>";
                    }
                }
                messages = messages.Replace("x", text);
                await _js.InvokeVoidAsync("showSnackbar", text);
            }
        }

        void SignInPage()
        {
            _navigator.NavigateTo("/login");
        }

        async Task CloseWindow()
        {
            await _js.InvokeVoidAsync("closeWindow");
        }

        byte[]? buf; //for Image
        async Task OnChange(InputFileChangeEventArgs e)
        {
            filesBase64.Clear();
            var files = e.GetMultipleFiles(); // get the files selected by the Users
            foreach (var file in files)
            {
                var resizedFile = await file.RequestImageFileAsync(file.ContentType, 258, 258); // resize the image file
                buf = new byte[resizedFile.Size]; // allocate a buffer to fill with the file's data
                using (var stream = resizedFile.OpenReadStream())
                {
                    await stream.ReadAsync(buf); // copy the stream to the buffer
                }
                filesBase64.Add(new ImageFile { base64data = Convert.ToBase64String(buf), contentType = file.ContentType, fileName = file.Name }); // convert to a base64 string!!
            }
            profileImage = buf;
        }
    }
}
