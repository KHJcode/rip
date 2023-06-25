using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingGame : MonoBehaviour
{
    public Text arrowText;
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public int arrowCount = 8;
    public GameObject fishPrefab;
    public GameObject squidPrefab;
    public GameObject eelPrefab;

    public GameObject player;
    public float fishDisplayTime = 2f;
    public float fishingRodDisplayTime = 2f;

    private string[] arrowArray;
    private int currentArrowIndex;
    private string[] originalArrowTextArray;
    private bool isDisplayingFish;
    private int correctArrowCount;

    public GameObject fishingRodPrefab;  // 낚시대 프리팹을 가리키는 변수
    private GameObject fishingRod;  // 생성된 낚시대를 저장할 변수

    private void Start()
    {
        arrowArray = new string[] { "<-", "->" };
        originalArrowTextArray = new string[arrowCount];
    }

    private void Update()
    {

        if (currentArrowIndex < arrowCount && !isDisplayingFish && (Input.GetKeyDown(leftKey) || Input.GetKeyDown(rightKey)))
        {
            string currentArrow = originalArrowTextArray[currentArrowIndex];
            bool isCorrect = false;

            if (Input.GetKeyDown(leftKey) && currentArrow == "<-")
            {
                //Vector3 rodPosition = new Vector3(-2f, -1f, -1f);
                
                fishingRod.transform.rotation = player.transform.rotation * Quaternion.Euler(0f, -20f, -90f);
                isCorrect = true;
            }
            else if (Input.GetKeyDown(rightKey) && currentArrow == "->")
            {
                //Vector3 rodPosition = new Vector3(-2f, -1f, -1f);
                
                fishingRod.transform.rotation = player.transform.rotation * Quaternion.Euler(0f, 20f, -90f);
                isCorrect = true;
            }
        


            if (isCorrect)
            {
                SetArrowTextBlue(currentArrowIndex);
                currentArrowIndex++;
                correctArrowCount++;

                if (correctArrowCount == arrowCount)
                {
                    DisplayFish();
                    EndGame();
                }
                /*else
                {
                    DisplayFish();
                }*/

            }
            else
            {
                ResetGame();
                Destroy(fishingRod);
            }
        }

    }

    public void StartGame()
    {
        Destroy(fishingRod);
        currentArrowIndex = 0;
        correctArrowCount = 0;
        arrowText.text = "";

        for (int i = 0; i < arrowCount; i++)
        {
            int randomIndex = Random.Range(0, arrowArray.Length);
            string arrowDirection = arrowArray[randomIndex];
            originalArrowTextArray[i] = arrowDirection;
            arrowText.text += arrowDirection + " ";
        }

        Vector3 rodPosition = player.transform.position+new Vector3(0f, 0f, 0f);
        Quaternion rodRotation = player.transform.rotation * Quaternion.Euler(0f, 0f, -90f);  // 기본 회전값
        fishingRod = Instantiate(fishingRodPrefab, rodPosition, rodRotation);

    }

    private void SetArrowTextBlue(int index)
    {
        string[] arrowTextArray = arrowText.text.Split(' ');
        arrowTextArray[index] = "<color=blue>" + arrowTextArray[index] + "</color>";
        arrowText.text = string.Join(" ", arrowTextArray);
    }

    private void ResetGame()
    {
        currentArrowIndex = 0;
        correctArrowCount = 0;
        arrowText.text = "";
    }

    private void EndGame()
    {
        fishingRod.transform.position = player.transform.position + new Vector3(0f, 0f, -1f);
        fishingRod.transform.rotation = player.transform.rotation * Quaternion.Euler(-80f, 50f, -120f);
        Debug.Log("게임 종료");
        ResetGame();
        Destroy(fishingRod, fishingRodDisplayTime);
        Invoke(nameof(ResetFishDisplay), fishingRodDisplayTime);
    }

    private void DisplayFish()
{
    isDisplayingFish = true;
    Vector3 spawnPosition = player.transform.position + new Vector3(0f, 0f, 0f);
    Quaternion spawnRotation = player.transform.rotation * Quaternion.Euler(0f, 200f, 0f); // 180도 회전값 설정

    GameObject fishPrefabToSpawn;
    int randomIndex = Random.Range(0, 3);

    if (randomIndex == 0)
        fishPrefabToSpawn = fishPrefab;
    else if (randomIndex == 1)
        fishPrefabToSpawn = squidPrefab;
    else
        fishPrefabToSpawn = eelPrefab;

    GameObject fish = Instantiate(fishPrefabToSpawn, spawnPosition, spawnRotation);
    Destroy(fish, fishDisplayTime);

    // Create a new fish object and set it as Pet
    GameObject petFish = Instantiate(fishPrefabToSpawn, spawnPosition, spawnRotation);
    petFish.tag = "Pet"; // Set the tag as "Pet"

    // Add Rigidbody component to the petFish
    Rigidbody petRigidbody = petFish.GetComponent<Rigidbody>();
    if (petRigidbody == null)
    {
        petRigidbody = petFish.AddComponent<Rigidbody>();
    }

    // Add Collider component to the petFish
    Collider petCollider = petFish.GetComponent<Collider>();
    if (petCollider == null)
    {
        petCollider = petFish.AddComponent<BoxCollider>(); // Change BoxCollider to the appropriate collider type
    }

    PetController petController = petFish.GetComponent<PetController>();
    if (petController == null)
    {
        petController = petFish.AddComponent<PetController>();
    }
    petController.player = player.transform;

    Invoke(nameof(ResetFishDisplay), fishDisplayTime);
}





    private void ResetFishDisplay()
    {
        isDisplayingFish = false;
    }
}
