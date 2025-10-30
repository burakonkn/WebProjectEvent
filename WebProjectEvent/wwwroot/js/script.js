document.addEventListener('DOMContentLoaded', () => {

    // Sadece 'kayit.html' sayfasındayken çalışacak kod
    const ticketCountInput = document.getElementById('bilet-sayisi');
    const pricePerTicketElement = document.getElementById('bilet-fiyati');
    
    // Eğer bu elementler sayfada varsa (yani kayıt sayfasındaysak)
    if (ticketCountInput && pricePerTicketElement) {
        
        const totalAmountElement = document.getElementById('toplam-tutar');
        const ticketCountSummaryElement = document.getElementById('bilet-sayisi-ozet');
        
        // data-price="250" attribute'ünden bilet fiyatını al
        const pricePerTicket = parseFloat(pricePerTicketElement.dataset.price);

        const updateTotalPrice = () => {
            const ticketCount = parseInt(ticketCountInput.value);
            
            // Geçerli bir sayı olduğundan emin ol
            if (isNaN(ticketCount) || ticketCount < 1) {
                ticketCountInput.value = 1;
                return;
            }
            
            const total = pricePerTicket * ticketCount;
            
            // Fiyatı ve adedi güncelle
            // toLocaleString 'tr-TR' ile ₺ formatını (örn: ₺250,00) sağlar
            totalAmountElement.textContent = `₺${total.toLocaleString('tr-TR')}`;
            ticketCountSummaryElement.textContent = ticketCount;
        };

        // Input değeri her değiştiğinde fonksiyonu çağır
        ticketCountInput.addEventListener('input', updateTotalPrice);

        // Sayfa ilk yüklendiğinde de bir kez çalıştır
        updateTotalPrice();
    }

});