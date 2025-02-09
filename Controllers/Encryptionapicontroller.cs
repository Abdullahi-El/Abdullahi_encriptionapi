using Microsoft.AspNetCore.Mvc;
using EncryptionAPI.Services;

namespace EncryptionAPI.Controllers
{
    [ApiController] // Anger att detta är en API-controller
    [Route("api/[controller]")] // Definierar basrouten för controlleren
    public class EncryptionController : ControllerBase
    {
        private readonly EncryptionService _encryptionService;

        // Konstruktor som tar emot EncryptionService via dependency injection
        public EncryptionController(EncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        // Endpoint för att kryptera text
        [HttpPost("encrypt")] // POST /api/encryption/encrypt
        public IActionResult Encrypt([FromBody] string plainText)
        {
            // Validera inmatning
            if (string.IsNullOrEmpty(plainText))
            {
                return BadRequest("Input text cannot be empty.");
            }

            // Anropa krypteringsmetoden från EncryptionService
            var encryptedText = _encryptionService.Encrypt(plainText);

            // Returnera det krypterade resultatet
            return Ok(encryptedText);
        }

        // Endpoint för att dekryptera text
        [HttpPost("decrypt")] // POST /api/encryption/decrypt
        public IActionResult Decrypt([FromBody] string encryptedText)
        {
            // Validera inmatning
            if (string.IsNullOrEmpty(encryptedText))
            {
                return BadRequest("Encrypted text cannot be empty.");
            }

            // Anropa dekrypteringsmetoden från EncryptionService
            var plainText = _encryptionService.Decrypt(encryptedText);

            // Returnera det dekrypterade resultatet
            return Ok(plainText);
        }
    }
}