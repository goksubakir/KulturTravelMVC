/* CONTACT FORM */
function sendMessage() {
    const name = document.getElementById("name").value;
    const email = document.getElementById("email").value;
    const message = document.getElementById("message").value;
    
    if (!name || !email || !message) {
        alert("Lütfen tüm alanları doldurun!");
        return false;
    }
    
    alert(`${name}, mesajınız başarıyla gönderildi ✅`);
    
    // Formu temizle
    document.getElementById("name").value = "";
    document.getElementById("email").value = "";
    document.getElementById("message").value = "";
    
    return false;
}

