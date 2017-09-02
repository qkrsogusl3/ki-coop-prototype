﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomDebug;


namespace MiniGame3
{
    public class ViewMiniGame3 : MonoBehaviour
    {

        
        public GameObject InstMiniGamePanel = null;                 // 미니겜 패널
        public GameObject InstCoinShopPanel = null;                 // 코인샵 패널
        
        public Button PFItemBtn = null;                             // 버튼 프리팹
        public List<Button> PFItemBtnList = null;

        private SceneMiniGame3 mScene = null;
        private int mCoin;                                          // 소지 코인


        private Item[] mItemImg = new Item[4];
        private ItemButton[] mItemBtn = new ItemButton[4];

        public List<ItemButton> ItemBtnList = new List<ItemButton>();
        public List<Item> ImageList = new List<Item>();

        private Vector2[] mButtonPos = new Vector2[4];

        void Start()
        {
            mButtonPos[0] = new Vector2(0, 65);
            mButtonPos[1] = new Vector2(100, 65);
            mButtonPos[2] = new Vector2(0, -65);
            mButtonPos[3] = new Vector2(100, -65);

            GetmItemImg();
            CreateButtons();
            
        }

        void Update()
        {

        }

        public void SetScene(SceneMiniGame3 scene)
        {
            mScene = scene;
        }

        

        public void CreateButtons()
        {
            for (int i = 0; i < ItemBtnList.Count; i++)
            {
                var tA = Instantiate(PFItemBtn, Vector2.zero, Quaternion.identity, InstMiniGamePanel.transform.GetChild(0));
                tA.transform.localPosition = mButtonPos[i];
                CDebug.Log(mButtonPos[i]);
                PFItemBtnList.Add(tA);

            }

            for (int ti = 0; ti < PFItemBtnList.Count; ti++)
            {
                PFItemBtnList[ti].onClick.AddListener(() => OnBtnItem(ImageList[ti].GetId()));
            }
        }

        // 버튼 아이디 기준으로 생성
        private void OnBtnItem(int ti)
        {
            CDebug.LogFormat("Item ID: {0}", ImageList[ti].GetId());
            if (true == ImageList[ti].isBought)
            {
                if (PFItemBtnList[ti])
                {
                    Instantiate(PFItemBtnList[ti], ImageList[ti].posImg, Quaternion.identity);
                }
            }
            // 코인 체크 && 구매 체크
            else if (ImageList[ti].GetPrice() > mCoin && false == ImageList[ti].isBought)
            {
                Instantiate(PFItemBtnList[ti], ImageList[ti].posImg, Quaternion.identity);
                ImageList[ti].isBought = true;
                mCoin -= ImageList[ti].GetPrice();
            }
        }



        public void GetmItemImg()
        {
            // 버튼 정보 초기화
            for (int ti = 0; ti < mItemBtn.Length; ti++)
            {
                mItemBtn[ti] = new ItemButton();
                mItemBtn[ti].SetId(ti);

                ItemBtnList.Add(mItemBtn[ti]);
            }
            // 버튼 생성 위치 저장
            mItemBtn[0].SetPos(Camera.main.WorldToScreenPoint(new Vector3(0, 65, 0)));
            mItemBtn[1].SetPos(Camera.main.WorldToScreenPoint(new Vector3(100, 65, 0)));
            mItemBtn[2].SetPos(Camera.main.WorldToScreenPoint(new Vector3(0, -65, 0)));
            mItemBtn[3].SetPos(Camera.main.WorldToScreenPoint(new Vector3(100, -65, 0)));



            // 아이템 정보 초기화
            for (int ti = 0; ti < mItemImg.Length; ti++)
            {
                mItemImg[ti] = new Item();
                mItemImg[ti].SetId(ti);
                //CDebug.LogFormat("ID {0} = {1}",ti,mItemImg[ti].GetId());
                mItemImg[ti].SetPrice(ti * 100);
                //CDebug.LogFormat("Price {0} = {1}", ti, mItemImg[ti].GetPrice());

                ImageList.Add(mItemImg[ti]);
            }
            // 이미지 생성 위치 저장
            mItemImg[0].posImg = new Vector2(-140, 60);     // 모자
            mItemImg[1].posImg = new Vector2(-135, 20);     // 안경
            mItemImg[2].posImg = new Vector2(-140, -100);   // 옷
            mItemImg[3].posImg = new Vector2(0, 0);         // none

            //mItemImg[0].GetImg("")

            for (int ti = 0; ti < mItemImg.Length; ti++)
            {
                ImageList.Add(mItemImg[ti]);
            }
        }




        public void OnClickGoCoinShop()
        {
            InstMiniGamePanel.SetActive(false);
            InstCoinShopPanel.SetActive(true);
        }
        public void OnClickGoMain()
        {

        }
        public void OnClickBtnItem()
        {

        }

    }
}
