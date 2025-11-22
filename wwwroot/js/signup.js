function signupUser() {
    const fullname = document.getElementById("fullname").value;
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    const confirmPassword = document.getElementById("confirmPassword").value;
  
    if (password !== confirmPassword) {
      alert("Şifreler eşleşmiyor!");
      return false;
    }
  
    const user = { fullname, email, password };
    localStorage.setItem("user", JSON.stringify(user));
  
    alert("Kayıt başarılı! Giriş sayfasına yönlendiriliyorsunuz...");
    window.location.href = "/Auth/Login";
    return false;
  }
  