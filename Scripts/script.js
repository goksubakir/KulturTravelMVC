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
      
      // Login/Signup linklerini kaldır
      const signupLink = nav.querySelector('a[href="signup.html"]');
      const loginLink = nav.querySelector('a[href="login.html"]');
      if (signupLink) signupLink.remove();
      if (loginLink) loginLink.remove();
      
      // Avatar container oluştur
      const avatarContainer = document.createElement("div");
      avatarContainer.classList.add("avatar-container");
      avatarContainer.innerHTML = `
        <div class="avatar-box">
          <img src="data:image/svg+xml,%3Csvg width='64' height='64' viewBox='0 0 64 64' fill='none' xmlns='http://www.w3.org/2000/svg'%3E%3Ccircle cx='32' cy='32' r='32' fill='%2300b4d8'/%3E%3Ccircle cx='32' cy='26' r='12' fill='%23fff'/%3E%3Cpath d='M12 56c2.5-9.5 10.5-16 20-16s17.5 6.5 20 16' stroke='%23fff' stroke-width='6' stroke-linecap='round'/%3E%3C/svg%3E" alt="avatar" class="avatar-img">
          <span>${user.fullname}</span>
        </div>
        <div class="avatar-dropdown" id="avatarDropdown">
          <a href="/Reservation/MyReservations">Rezervasyonlarım</a>
          <a href="#" class="logout-link">Çıkış Yap</a>
        </div>
      `;
      
      nav.appendChild(avatarContainer);
      
      // Dropdown toggle
      const avatarBox = avatarContainer.querySelector(".avatar-box");
      const dropdown = avatarContainer.querySelector(".avatar-dropdown");
      
      avatarBox.addEventListener("click", (e) => {
        e.stopPropagation();
        e.preventDefault();
        const isOpen = dropdown.classList.contains("open");
        
        // Tüm dropdown'ları kapat
        document.querySelectorAll(".avatar-dropdown").forEach(dd => {
          dd.classList.remove("open");
        });
        
        // Bu dropdown'ı aç/kapat
        if (!isOpen) {
          dropdown.classList.add("open");
        }
      });
      
      // Dropdown içindeki linklere tıklama
      const dropdownLinks = avatarContainer.querySelectorAll(".avatar-dropdown a");
      dropdownLinks.forEach(link => {
        link.addEventListener("click", (e) => {
          if (!link.classList.contains("logout-link")) {
            dropdown.classList.remove("open");
          }
        });
      });
      
      // Dışarı tıklayınca dropdown'ı kapat
      document.addEventListener("click", (e) => {
        if (!avatarContainer.contains(e.target)) {
          dropdown.classList.remove("open");
        }
      });
      
      // Logout işlemi
      const logoutLink = avatarContainer.querySelector(".logout-link");
      if (logoutLink) {
        logoutLink.addEventListener("click", (e) => {
          e.preventDefault();
          e.stopPropagation();
          dropdown.classList.remove("open");
          localStorage.clear();
          setTimeout(() => {
            window.location.href = "/Auth/Login";
          }, 100);
        });
      }
    }
  });
  