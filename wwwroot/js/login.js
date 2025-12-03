function loginUser() {
    const email = document.getElementById("loginEmail").value;
    const password = document.getElementById("loginPassword").value;
    const storedUser = JSON.parse(localStorage.getItem("user"));
  
    if (!storedUser) {
      alert("Henüz kayıtlı kullanıcı bulunamadı!");
      return false;
    }
  
    if (email === storedUser.email && password === storedUser.password) {
      alert(`Hoş geldiniz, ${storedUser.fullname}!`);
      localStorage.setItem("loggedIn", "true");
      window.location.href = "/Home/Index";
    } else {
      alert("E-posta veya şifre hatalı!");
    }
  
    return false;
  }
  