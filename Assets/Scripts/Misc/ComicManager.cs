using UnityEngine;
using UnityEngine.UI;

public class ComicManager : MonoBehaviour
{
    [SerializeField]
    Text nextText;

    [SerializeField]
    GameObject[] pages;

    public int currPage;
    Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
        currPage = 0;
        GotoPage(currPage);
        SoundManager.getInstance().play_BGM_Comic();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, .1f);
    }

    public void NextPage()
    {
        currPage++;
        if (currPage == pages.Length - 1)
            nextText.text = "Ayo Lawan!";
        if (currPage == pages.Length)
            Skip();
        else
            GotoPage(currPage);
    }

    private void GotoPage(int id)
    {

        targetPos.x = pages[id].transform.position.x;
        targetPos.y = pages[id].transform.position.y;

    }

    public void Skip()
    {
        PlayerPrefs.SetInt("comic", 1);
        PlayerPrefs.Save();
        GameManager.Instance.GotoGameplay();

    }


}
