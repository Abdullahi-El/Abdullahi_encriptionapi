using Microsoft.AspNetCore.Mvc;
using EncryptionAPI.Services;

namespace EncryptionAPI.Controllers
{
    [ApiController] // Anger att detta �r en API-controller
    [Route("api/[controller]")] // Definierar basrouten f�r controlleren
    public class EncryptionController : ControllerBase
    {
        private readonly EncryptionService _encryptionService;

        // Konstruktor som tar emot EncryptionService via dependency injection
        public EncryptionController(EncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        // Endpoint f�r att kryptera text
        [HttpPost("encrypt")] // POST /api/encryption/encrypt
        public IActionResult Encrypt([FromBody] string plainText)
        {
            // Validera inmatning
            if (string.IsNullOrEmpty(plainText))
            {
                return BadRequest("Input text cannot be empty.");
            }

            // Anropa krypteringsmetoden fr�n EncryptionService
            var encryptedText = _encryptionService.Encrypt(plainText);

            // Returnera det krypterade resultatet
            return Ok(encryptedText);
        }

        // Endpoint f�r att dekryptera text
        [HttpPost("decrypt")] // POST /api/encryption/decrypt
        public IActionResult Decrypt([FromBody] string encryptedText)
        {
            // Validera inmatning
            if (string.IsNullOrEmpty(encryptedText))
            {
                return BadRequest("Encrypted text cannot be empty.");
            }

            // Anropa dekrypteringsmetoden fr�n EncryptionService
            var plainText = _encryptionService.Decrypt(encryptedText);

            // Returnera det dekrypterade resultatet
            return Ok(plainText);
        }
    }
}