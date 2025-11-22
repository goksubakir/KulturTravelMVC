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
      
      // Set session on server
      fetch('/Auth/SetSession', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded',
        },
        body: `email=${encodeURIComponent(email)}&name=${encodeURIComponent(storedUser.fullname)}`
      }).then(() => {
        window.location.href = "/Home/Index";
      });
    } else {
      alert("E-posta veya şifre hatalı!");
    }
  
    return false;
  }
  