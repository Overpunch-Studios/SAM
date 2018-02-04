<?php

namespace App\Http\Controllers;

use App\Command;

class CommandControllerApi extends Controller
{
    public function index() {
        $commands = Command::all();

        return $commands;
    }

    public function range() {
        $commands = Command::all();
        $result = [];
        $ids = "";

        foreach ($commands as $command)
        {
            $ids .= $command->id . ',';
        }

        $ids = rtrim($ids, ',');

        $result = ['ids'=>$ids];

        return $result;
    }

    public function show($id) {
        $command = Command::find($id);

        return $command;
    }
}
