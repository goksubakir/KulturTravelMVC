function showAlert() {
    alert("Seyahat planlamanıza başlamak için üye olun!");
  }
  
  /* CONTACT FORM */
  function sendMessage() {
    const name = document.getElementById("name").value;
    const msg = document.getElementById("msgSent");
    msg.style.display = "block";
    msg.textContent = `${name}, mesajınız başarıyla gönderildi ✅`;
    return false;
  }
  
  
  /* SIGNUP */
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
    window.location.href = "login.html";
    return false;
  }
  
  /* LOGIN */
  function loginUser() {
    const email = document.getElementById("loginEmail").value;
    const password = document.getElementById("loginPassword").value;
    const storedUser = JSON.parse(localStorage.getItem("user"));
    if (!storedUser) {
      alert("Henüz kayıtlı kullanıcı bulunamadı."); return false;
    }
    if (email === storedUser.email && password === storedUser.password) {
      alert(`Hoş geldiniz ${storedUser.fullname}!`);
      localStorage.setItem("loggedIn", "true");
      window.location.href = "index.html";
    } else alert("E-posta veya şifre hatalı!");
    return false;
  }
  
  /* SLIDER + AVATAR */
  document.addEventListener("DOMContentLoaded", () => {
    // Slider
    let currentSlide = 0;
    const slides = document.querySelectorAll(".slider img");
    if (slides.length > 0) {
      function changeSlide() {
        slides[currentSlide].classList.remove("active");
        currentSlide = (currentSlide + 1) % slides.length;
        slides[currentSlide].classList.add("active");
      }
      setInterval(changeSlide, 3000);
    }
  
    // Avatar
    const user = JSON.parse(localStorage.getItem("user"));
    const loggedIn = localStorage.getItem("loggedIn");
    if (loggedIn === "true" && user) {
      const nav = document.querySelector("nav");
      const avatar = document.createElement("div");
      avatar.classList.add("avatar-box");
      avatar.innerHTML = `
        <img src="web-gorseller/7.png" alt="avatar" class="avatar-img" title="Çıkış yapmak için tıklayın">
        <span>${user.fullname}</span>
      `;
      const signupLink = nav.querySelector('a[href="signup.html"]');
      const loginLink = nav.querySelector('a[href="login.html"]');
      if (signupLink) signupLink.remove();
      if (loginLink) loginLink.remove();
      nav.appendChild(avatar);
      avatar.addEventListener("click", () => {
        const confirmLogout = confirm("Çıkış yapmak istediğinize emin misiniz?");
        if (confirmLogout) {
          localStorage.clear();
          alert("Çıkış yapıldı!");
          window.location.replace("index.html");
        }
      });
    }
  });
  