using System;
using System.Globalization;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterApp.Data;
using RegisterApp.Models;
using System.Text;


namespace RegisterApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        /*
       // PUT: api/Users/5
       // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       [HttpPut("{id}")]
       public async Task<IActionResult> PutUser(int id, User user)
       {
           if (id != user.Id)
           {
               return BadRequest();
           }

           _context.Entry(user).State = EntityState.Modified;

           try
           {
               await _context.SaveChangesAsync();
           }
           catch (DbUpdateConcurrencyException)
           {
               if (!UserExists(id))
               {
                   return NotFound();
               }
               else
               {
                   throw;
               }
           }

           return NoContent();
       } */

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'AppDbContext.Users'  is null.");
            }

            User updateuser = new User();

            //HASH PASSWORD
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            // derive a 512-bit subkey (use HMACSHA512 with 100 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 100,
                numBytesRequested: 512 / 8));

            updateuser.password = hashed;

            //validate username (to be unique)
            var username = (_context.Users?.Any(e => e.username == user.username)).GetValueOrDefault();
            if (!username) { updateuser.username = user.username; }
            else { return Problem("username should be unique"); }


            updateuser.firstname = user.firstname;
            updateuser.fathername = user.fathername;
            updateuser.familyname = user.familyname;

            //Personal Data
            
            /* using (SymmetricAlgorithm myAes = SymmetricAlgorithm.Create())
            {
                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes_Aes(user.address, myAes.Key, myAes.IV);
                updateuser.address = Encoding.Default.GetString(encrypted);
                encrypted = EncryptStringToBytes_Aes(user.occupation, myAes.Key, myAes.IV);
                updateuser.occupation = Encoding.Default.GetString(encrypted);
            }*/
            updateuser.birthdate = user.birthdate;
            updateuser.address = user.address;
            updateuser.occupation = user.occupation;

            //Add data to database 
            _context.Users.Add(updateuser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, updateuser);
        }

        /*
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        } */

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        /*
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (SymmetricAlgorithm aesAlg = SymmetricAlgorithm.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        } */
    }
}
