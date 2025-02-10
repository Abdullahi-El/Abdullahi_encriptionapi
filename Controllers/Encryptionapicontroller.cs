using Microsoft.AspNetCore.Mvc;
using EncryptionAPI.Services;

namespace EncryptionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptionController : ControllerBase
    {
        private readonly Encryptionspi _encryptionService; // Correct the service name

        // Constructor for dependency injection of Encryptionspi
        public EncryptionController(Encryptionspi encryptionService)
        {
            _encryptionService = encryptionService; // Initialize the service
        }

        // POST endpoint for encrypting text
        [HttpPost("encrypt")]
        public ActionResult<string> Encrypt([FromBody] string plainText)
        {
            var encryptedText = _encryptionService.Encrypt(plainText); // Use Encrypt method from Encryptionspi
            return Ok(encryptedText); // Return the encrypted text
        }

        // POST endpoint for decrypting text
        [HttpPost("decrypt")]
        public ActionResult<string> Decrypt([FromBody] string cipherText)
        {
            var decryptedText = _encryptionService.Decrypt(cipherText); // Use Decrypt method from Encryptionspi
            return Ok(decryptedText); // Return the decrypted text
        }

        // GET endpoint for encrypting text (alternative to POST)
        [HttpGet("encrypt")]
        public ActionResult<string> GetEncrypt([FromQuery] string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                return BadRequest("Plain text is required.");
            }
            var encryptedText = _encryptionService.Encrypt(plainText); // Use Encrypt method from Encryptionspi
            return Ok(encryptedText); // Return the encrypted text
        }

        // GET endpoint for decrypting text (alternative to POST)
        [HttpGet("decrypt")]
        public ActionResult<string> GetDecrypt([FromQuery] string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
            {
                return BadRequest("Cipher text is required.");
            }
            var decryptedText = _encryptionService.Decrypt(cipherText); // Use Decrypt method from Encryptionspi
            return Ok(decryptedText); // Return the decrypted text
        }
    }
}
